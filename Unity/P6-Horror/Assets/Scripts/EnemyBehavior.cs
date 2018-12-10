using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {

    public float detectionDistance;
    public float detectionAngle;
    public Transform player;
    private Vector3 playerDirection;
    private float playerDistance;
    private float playerAngle;
    private RaycastHit hit;
    private bool lost;
    private Vector3 lastKnown;

    public Transform target;
    public List<Transform> targetList = new List<Transform>();
    private NavMeshAgent agent;

    private enum action { wander, scan, hunt, search };
    private action current;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        SelectTarget();
        print(targetList.Count);
        lost = true;
	}
	
	// Update is called once per frame
	void Update () {
        Vision();
		switch (current)
        {
            case action.wander:
                //behavior here
                if(transform.position.z == target.position.z && transform.position.x == target.position.x)
                {
                    current = action.scan;
                }
                break;

            case action.scan:
                //behavior here
                SelectTarget();
                break;

            case action.hunt:
                //behavior here
                if(lost == true)
                {
                    current = action.search;
                }
                break;

            case action.search:
                //behavior here
                target.position = lastKnown;
                if (transform.position.z == target.position.z && transform.position.x == target.position.x)
                {
                    current = action.scan;
                }
                break;
        }
	}

    private void Vision()
    {
        playerDirection = player.position - transform.position;
        playerDistance = Mathf.Sqrt(Mathf.Pow((player.position.z - transform.position.z), 2) + Mathf.Pow((player.position.x - transform.position.x), 2));
        playerAngle = Vector3.Angle(playerDirection, transform.forward);
        Debug.DrawRay(transform.position, playerDirection);
        if(playerAngle <= detectionAngle && playerDistance <= detectionDistance && Physics.Raycast(transform.position, playerDirection, out hit, detectionDistance))
        {
            if(hit.transform.gameObject.tag == "Player")
            {
                lost = false;
                target = player;
                agent.destination = player.position;
                current = action.hunt;
            }
            else
            {
                lost = true;
                lastKnown = player.position;
            }
        }
    }

    private void SelectTarget()
    {
        int i = Random.Range(0, targetList.Count);
        target = targetList[i];
        agent.destination = target.position;
        current = action.wander;
    }
}

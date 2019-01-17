using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Player Interaction")]
    public float detectionDistance;
    public float detectionAngle;
    public Transform player;
    public float killDistance;
    private Vector3 playerDirection;
    private float playerDistance;
    private float playerAngle;
    private RaycastHit hit;
    private bool lost;
    private Vector3 lastKnown;

    [Header("Target Tracking")]
    public GameObject tempTarget;
    public Transform target;
    public List<Transform> targetList = new List<Transform>();
    private List<GameObject> tempTargetList = new List<GameObject>();
    private NavMeshAgent agent;

    [Header("Sound")]
    public AudioClip clip;
    public AudioSource source;
    private float volume;

    private enum action { wander, scan, hunt, search };
    private action current;

    // Use this for initialization
    void Start()
    {
        volume = source.volume;
        agent = GetComponent<NavMeshAgent>();
        SelectTarget();
        print(targetList.Count);
        lost = true;
        GetComponent<SphereCollider>().radius = killDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Volume();
        Vision();
        switch (current)
        {
            case action.wander:
                //behavior here
                if (transform.position.z == target.position.z && transform.position.x == target.position.x)
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
                if (lost == true)
                {
                    target = Instantiate(tempTarget, lastKnown, Quaternion.identity).transform;
                    tempTargetList.Add(target.gameObject);
                    current = action.search;
                }
                break;

            case action.search:
                //behavior here
                agent.destination = target.position;
                if (transform.position.z == target.position.z && transform.position.x == target.position.x)
                {
                    foreach(GameObject g in tempTargetList)
                    {
                        Destroy(g);
                    }
                    current = action.scan;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInChildren<PlayerInteraction>().stalked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<PlayerInteraction>().stalked = false;
        }
    }

    private void Vision()
    {
        playerDirection = player.position - transform.position;
        playerDistance = Mathf.Sqrt(Mathf.Pow((player.position.z - transform.position.z), 2) + Mathf.Pow((player.position.x - transform.position.x), 2));
        playerAngle = Vector3.Angle(playerDirection, transform.forward);
        Debug.DrawRay(transform.position, playerDirection);
        if (playerAngle <= detectionAngle && playerDistance <= detectionDistance && Physics.Raycast(transform.position, playerDirection, out hit, detectionDistance))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                lost = false;
                target = player;
                agent.destination = player.position;
                current = action.hunt;
                Scare();
            }
            else
            {
                lost = true;
                lastKnown = player.position;
                //current = action.search;
            }
        }
        else
        {
            lost = true;
            lastKnown = player.position;
            //current = action.search;
        }
    }

    private void SelectTarget()
    {
        int i = Random.Range(0, targetList.Count);
        target = targetList[i];
        agent.destination = target.position;
        current = action.wander;
    }

    private void Volume()
    {
        source.volume = volume / playerDistance;
    }

    private void Scare()
    {
        player.gameObject.GetComponent<Movement>().Scared();
    }
}

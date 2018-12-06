using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float detectionDistance;
    public float detectionAngle;
    public Transform player;
    private Vector3 playerDirection;
    private float playerDistance;
    private float playerAngle;

    public Transform target;
    public List<Transform> targetList = new List<Transform>();

    private enum action { wander, scan, hunt, search };
    private action current;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (current)
        {
            case action.wander:
                //behavior here
                break;

            case action.scan:
                //behavior here
                break;

            case action.hunt:
                //behavior here
                break;

            case action.search:
                //behavior here
                break;
        }
	}

    private void Vision()
    {
        playerDirection = player.position - transform.position;
        playerDistance = Mathf.Sqrt(Mathf.Pow((player.position.z - transform.position.z), 2) + Mathf.Pow((player.position.x - transform.position.x), 2));
        playerAngle = Vector3.Angle(playerDirection, transform.forward);
    }
}

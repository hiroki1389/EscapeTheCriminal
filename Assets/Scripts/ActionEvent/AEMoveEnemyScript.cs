using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Takanaga.
// attached to Enemy objects of the final action event in MainScene.
public class AEMoveEnemyScript : MonoBehaviour
{  
    [SerializeField] private float MOVING_SPEED = 10.0f;
    private const float WAIT_TIME = 0.3f;
    private const float TURN_SPEED = 90.0f;
    
    private GameObject player;
    [SerializeField] private Transform pathHolder;


    private void Start(){
        player = GameObject.Find("Car_root");

        Vector3[] waypoints = new Vector3[pathHolder.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
                waypoints[i] = pathHolder.GetChild(i).position;
                waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }
        
        StartCoroutine(FollowPath(waypoints));
    }

    private void Update() { }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, MOVING_SPEED * Time.deltaTime);
            if(transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(WAIT_TIME);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            yield return null;
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90.0f - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while(Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, TURN_SPEED * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }

    }

}

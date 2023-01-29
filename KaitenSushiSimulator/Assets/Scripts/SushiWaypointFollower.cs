using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiWaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .001f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        if(currentWaypointIndex == 3)
        {
            transform.position = waypoints[currentWaypointIndex].transform.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }        
    }
}

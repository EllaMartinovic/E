using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neprijatelj : MonoBehaviour
{
    public Transform[] waypoints;
    public float movespeed = 0.2f;
    private int waypointIndex = 0;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = GameObject.Find("WayPoint").transform.position; 
    }
    private void FixedUpdate()
    {
            if(waypointIndex<=waypoints.Length-1)
        {
            Vector2 newposition = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, movespeed);
            rb.MovePosition(newposition);
            if (transform.position==waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                if (waypointIndex<waypoints.Length)
                {
                    Vector3 direction = waypoints[waypointIndex].transform.position - this.transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.rotation = angle;


                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

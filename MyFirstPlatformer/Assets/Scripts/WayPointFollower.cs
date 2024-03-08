using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;

    private int CurrentIndexWay = 0;
    [SerializeField] private float speed = 3f;
    private void Update()
    {
       if (Vector2.Distance(waypoints[CurrentIndexWay].transform.position,transform.position)< .1f)
        {
            CurrentIndexWay++;
            if (CurrentIndexWay >= waypoints.Length) 
            { 
                CurrentIndexWay = 0; 
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentIndexWay].transform.position, Time.deltaTime * speed);
    }
}

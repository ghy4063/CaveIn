using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySharkCrab : MonoBehaviour {
	//public variables
	[Header("List of waypoints")]
	//the list of waypoints
	public Transform[] Points;
	public float Speed;
	public bool shark;
	//private variables
	private int DestPoint=0;
	private Transform Destination;
	private Transform tf;
	private float dist;
	public bool shark;
	// Use this for initialization
	void Start () {
		if (Points.Length > 0) {
			//always makes sure that enemy starts partolling
			Destination = Points [0];
		}
		tf = this.GetComponent<Transform> ();
	}
		
	// Update is called once per frame
	void Update () {
		//gets the distance between the enemy and destination
		dist = Vector3.Distance (tf.position, Destination.position);
		//checks if you are close enough to turn around and go to the next point
		if(dist<0.5f){
			//TODO flip here
			if (shark == true) {
				transform.Rotate (0, 180, 0);
			}//change point to move to
			DestPoint = (DestPoint + 1) % Points.Length;
		}
		//speed at which the enemy moves
		float steps = Speed * Time.deltaTime;
		Destination = Points [DestPoint];
		//moves enemy to waypoint
		tf.position = Vector3.MoveTowards (tf.position, Destination.position, steps);
	}
}


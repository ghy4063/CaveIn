using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksFall : MonoBehaviour {
	private bool Rocks;
	[Header("The rocks that will block the passage")]
	public GameObject rocks;
	[Header("Place where the rocks will spawn")]
	public Transform position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//when player touches the treasure do stuff
	void OnTriggerEnter(Collider other){
		//check if it is the player
		if (other.gameObject.tag == "Player") {
			//create rock slide
			Instantiate (rocks, position);
		}
	}
}

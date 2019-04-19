using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steamvents : MonoBehaviour {
	public GameObject steam;
	private bool activate;
	public float timer=3.0f;
	public float cooldown;
	private float timerb;
	// Use this for initialization
	void Start () {
	timerb = timer;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerb >= 0) {
			activate = true;
			timerb -= Time.deltaTime;
			steam.SetActive(true);
			cooldown = 3;
		}
		else if (cooldown >= 0) {
			cooldown -= Time.deltaTime;
			steam.SetActive (false);
			if (cooldown <= 0) {
				timerb = timer;
			}
		}

			
	}
}

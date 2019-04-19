using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOctopus : MonoBehaviour {
	public float Speed;
	public bool isSpinning;
	public Animator anim;
	public SphereCollider Octo;
	public float radiusinc;
	public float radiusdec;
	private float timer=1f;
	private float timeremain=8f;

	// Use this for initialization
	void Start () {
		//rend = GetComponent<Renderer> ();
		Octo = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		radiusinc = Octo.radius;
		//if spinning octopus it is true
		if (isSpinning == true) {
			//spin in circle
			transform.Rotate (0, 0, Speed);
		}

		if (timer < timeremain) {
			timeremain -= timeremain * Time.deltaTime;
			Octo.radius -= radiusdec;
			//timerinc=3
		} 
		else if (timer>timeremain) {
			Octo.radius += radiusdec;
			if(radiusinc>=1.15f){
			timeremain = 8f;
			}
		}
		//Vector3 center = rend.bounds.center;
		//float radius = rend.bounds.extents.magnitude;
		//Vector3 Octocenter;
		//Vector3 Octosize,octomin,octomax;
		//Octocenter = center;
		//Octosize = Octo.bounds.size;



	}


	}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerBox : MonoBehaviour {

	public void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			GameManager.gameManager.playerWon = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager gameManager;

	public SubmarineController player;

	public List<GameObject> maps;

	[HideInInspector]
	public bool playerWon;

	void Awake () {
		if (gameManager == null) {
			gameManager = this;
		} else {
			Destroy (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.playerHealth <= 0) {
			player.gameObject.SetActive (false);
			UIManager.uiManager.loseMenu.SetActive (true);

			maps[0].SetActive(false);
		}

		if (playerWon == true) {
			player.gameObject.SetActive (false);
			UIManager.uiManager.winMenu.SetActive (true);

			maps[0].SetActive(false);
		}
	}
}

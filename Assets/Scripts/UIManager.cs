using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public static UIManager uiManager;

	public GameObject mainMenu;
	public GameObject winMenu;
	public GameObject loseMenu;
	public GameObject playerHealth1;
	public GameObject playerHealth2;
	public GameObject playerHealth3;

	public bool startGame = false;

	void Awake () {
		if (uiManager == null) {
			uiManager = this;
		} else {
			Destroy (this);
		}
	}

	void Update () {
		if (startGame == false) {
			return;
		}
		if (GameManager.gameManager.player.playerHealth == 2) {
			playerHealth1.SetActive (true);
			playerHealth2.SetActive (true);
			playerHealth3.SetActive (false);
		} else if (GameManager.gameManager.player.playerHealth == 1) {
			playerHealth1.SetActive (true);
			playerHealth2.SetActive (false);
			playerHealth3.SetActive (false);
		} else if (GameManager.gameManager.player.playerHealth <= 0) {
			playerHealth1.SetActive (false);
			playerHealth2.SetActive (false);
			playerHealth3.SetActive (false);
		} else {
			playerHealth1.SetActive (true);
			playerHealth2.SetActive (true);
			playerHealth3.SetActive (true);
		}
	}

	public void StartGame () {
		GameManager.gameManager.player.playerCamera.GetComponent<CameraFollow> ().targetToFollow = GameManager.gameManager.player.gameObject.transform;
		int randomMap = Random.Range (0, GameManager.gameManager.maps.Count);
		GameManager.gameManager.maps [randomMap].SetActive (true);
		mainMenu.SetActive (false);
		GameManager.gameManager.player.stopPlayerControls = false;
		startGame = true;
	}

	public void Quit () {
		Application.Quit ();
	}

	public void BackToMainMenu () {
		SceneManager.LoadScene ("Cave 1");
	}

}

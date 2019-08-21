using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
	public bool GisPaused;
	public GameObject pauseMenuCanvas;
	public GameObject pauseMenuYesNoCanvas;
	public GameObject joystickController;
	public GameObject [] buttons;

	void Update(){
		if (GisPaused) {
			pauseMenuCanvas.SetActive (true);
			joystickController.SetActive (false);
			foreach (GameObject i in buttons) {
				i.SetActive (false);
			}
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			joystickController.SetActive (true);
			foreach (GameObject i in buttons) {
				i.SetActive (true);
			}
			Time.timeScale = 1f;
		}
	}
		
	public void MainMenu(){
		SceneManager.LoadScene ("Menu");
	}
	public void ReloadScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}

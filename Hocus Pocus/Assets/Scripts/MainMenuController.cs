using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
	
	public Text scoretxt;
	public AudioSource Music;
	public Image SoundImage, MusicImage;
	public Sprite I1, I2, I3, I4;

	public void Play(){
		SceneManager.LoadScene ("Main");
	}

	void Awake(){
		if(!PlayerPrefs.HasKey("highScore")){
			PlayerPrefs.SetInt ("highScore", 0);
		}
		if (!PlayerPrefs.HasKey ("music")) {
			PlayerPrefs.SetInt ("music", 1);
		}
		if (!PlayerPrefs.HasKey ("sound")) {
			PlayerPrefs.SetInt ("sound", 1);
		}
		Music = this.GetComponent<AudioSource> ();

		string a = PlayerPrefs.GetInt ("highScore").ToString ();
		scoretxt.text = a;
	}

	void Update(){
		bool a;
		if (PlayerPrefs.GetInt ("music") == 1) {
			a = true;
			MusicImage.sprite = I2;
		} else {
			a = false;
			MusicImage.sprite = I1;
		}
		Music.mute = a;

		if (PlayerPrefs.GetInt ("sound") == 1)
			SoundImage.sprite = I4; 
		else
			SoundImage.sprite = I3;
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void MusicButton(){
		if (PlayerPrefs.GetInt ("music") == 1) {
			PlayerPrefs.SetInt ("music", 0);

		} else {
			PlayerPrefs.SetInt ("music", 1);

		}
	}

	public void SoundButton(){
		if (PlayerPrefs.GetInt ("sound") == 1)
			PlayerPrefs.SetInt ("sound", 0);
		else
			PlayerPrefs.SetInt ("sound", 1);
	}
}

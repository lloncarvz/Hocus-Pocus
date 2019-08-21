using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static int score;
	public Text scoreTxt;

	public Transform Spawn1, Spawn2, Spawn3;
	public GameObject [] Enemies;
	public float SpawnRate;
	private float SpawnTimer;

	public Text TimerTxt;
	public float Timer;
	private int Timer2;

	public GameOverMenu gameOverMenu;
	public Text gameOverScoreTxt;

	public AudioSource Music;

	void Awake(){
		SpawnTimer = Time.time;
		Music = this.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("music") == 1)
			Music.mute = true;
	}

	void Start () {
		score = 0;
		Timer2 = (int)Timer;
		TimerTxt.text = Timer2.ToString();
	}

	void Update () {
		scoreTxt.text = "" + score;
		Timer -= Time.deltaTime;
		Timer2 = (int)Timer;
		TimerTxt.text = Timer2.ToString();
		if (Timer2 == 0) {
			GameOver ();
		}

		if (SpawnTimer < Time.time) {
			GameObject Enemy1 = (GameObject)Instantiate (EnemySelect ());
			Enemy1.transform.position = Spawn1.position;
			GameObject Enemy2 = (GameObject)Instantiate (EnemySelect ());
			Enemy2.transform.position = Spawn2.position;
			GameObject Enemy3 = (GameObject)Instantiate (EnemySelect ());
			Enemy3.transform.position = Spawn3.position;
			SpawnTimer = Time.time + SpawnRate;
		}
	}

	public static void AddPoints(int pointsToAdd){
		score += pointsToAdd;
	}

	GameObject EnemySelect(){
		float which = Random.Range (0, 100);
		if (which > 30) {
			return Enemies [0];
		} else if (which <= 30 && which > 15) {
			return Enemies [1];
		} else if (which <= 15 && which > 5) {
			return Enemies [3];
		} else {
			return Enemies [2];
		}
	}

	public void GameOver(){
		//pauseMenu.isPaused2 = true;
		int a = PlayerPrefs.GetInt ("highScore");
		if (score > a) {
			PlayerPrefs.SetInt ("highScore", score);
		}
		gameOverMenu.GisPaused = true;
		gameOverScoreTxt.text = score.ToString ();
	}
}

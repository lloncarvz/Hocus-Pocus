using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;
	public int dir = 0;

	public AudioSource Sound;

	void Start(){
		Sound = this.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("sound") == 1)
			Sound.mute = true;
	}
	void Update () 
	{
		if (dir == 0) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		} else if (dir == 1) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		} else if (dir == 2) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else {
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}

		if (transform.position.y > 2.6 || transform.position.y < -2.6 || transform.position.x > 2.57 || transform.position.x < -2.57) {
			Destroy (gameObject);
		}

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "EnemyTag") {
			Destroy (gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public float speed;
	public int hp;
	public int diff;
	public Transform playerPos;

	void Start(){
		playerPos = GameObject.FindGameObjectWithTag ("PlayerTag").transform;
	}

	void Update(){
		transform.position = Vector2.MoveTowards (transform.position, playerPos.position, speed * Time.deltaTime);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "BoltTag") {
			hp--;
			if (hp == 0) {
				GameController.AddPoints (diff * 10);
				Destroy (gameObject);
			}
		}
	}
}

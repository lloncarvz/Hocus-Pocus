using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidBody;
	private Vector3 moveInput;
	private Vector3 moveVelocity;
	public VirtualJoystick moveJoystick;
	public GameObject boltGO;
	public GameController gameControl;

	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		float xAxis = Input.GetAxisRaw ("Horizontal");
		float yAxis = Input.GetAxisRaw ("Vertical");
		moveInput = new Vector3 (xAxis, yAxis);
		if (moveInput.magnitude > 1)
			moveInput.Normalize ();
		if (moveJoystick.inputVector != Vector3.zero) {
			moveInput = moveJoystick.inputVector;
		}


		moveVelocity = moveInput * moveSpeed;


	}

	public void ShootRight (){
		GameObject bolt1 = (GameObject)Instantiate (boltGO);
		bolt1.transform.position = new Vector2 (transform.position.x + 0.075f, transform.position.y);
		BulletController bc = bolt1.GetComponent<BulletController> ();
		bc.dir = 0;
	}

	public void ShootLeft (){
		GameObject bolt1 = (GameObject)Instantiate (boltGO);
		bolt1.transform.position = new Vector2 (transform.position.x - 0.075f, transform.position.y);
		BulletController bc = bolt1.GetComponent<BulletController> ();
		bc.dir = 1;
	}

	public void ShootUp (){
		GameObject bolt1 = (GameObject)Instantiate (boltGO);
		bolt1.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.1f);
		BulletController bc = bolt1.GetComponent<BulletController> ();
		bc.dir = 2;
	}

	public void ShootDown (){
		GameObject bolt1 = (GameObject)Instantiate (boltGO);
		bolt1.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.1f);
		BulletController bc = bolt1.GetComponent<BulletController> ();
		bc.dir = 3;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EnemyTag") {
			//Destroy (gameObject);
			gameControl.GameOver ();
		}
	}


	void FixedUpdate(){
		myRigidBody.velocity = moveVelocity;
	}
}

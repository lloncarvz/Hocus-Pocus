using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float smoothSpeed;
	public Vector3 offset;

	void LateUpdate()
	{
		transform.position = target.position + offset;
	}

}

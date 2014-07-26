using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float speed = 0.0f;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 newPosition = new Vector3 (transform.position.x +speed, transform.position.y, transform.position.z);
		transform.position = newPosition;
	}
}

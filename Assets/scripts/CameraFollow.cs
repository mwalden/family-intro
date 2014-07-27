using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float speed = 0.0f;
	// Use this for initialization
	public float maxX;
	public float minX;
	public float minBumperPosition = 0;
	public float maxBumperPosition = 0;
	private Camera cam;
	public GameObject objectToFollow;
	private CharacterMove move;

	void Start () {
		cam = Camera.main;
		speed = objectToFollow.GetComponent<CharacterMove> ().speed;


	}
	
	// Update is called once per frame
	void Update () {
		if ((objectToFollow.transform.position.x - transform.position.x )>= maxX) {
		
			cam.transform.position  = new Vector3(Mathf.Min(this.transform.position.x + (speed * Time.deltaTime), maxBumperPosition), this.transform.position.y,this.transform.position.z);
			return;
		}

		if ((objectToFollow.transform.position.x < transform.position.x) && (objectToFollow.transform.position.x - transform.position.x ) < minX) {

			cam.transform.position = new Vector3(Mathf.Max(this.transform.position.x - (speed * Time.deltaTime),minBumperPosition), this.transform.position.y,this.transform.position.z);
			return;
		}
	}
}

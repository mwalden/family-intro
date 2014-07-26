using UnityEngine;
using System.Collections;

public class EndIntroScene : MonoBehaviour {
	public float speed;
	public bool moveOffScreen;
	// Use this for initialization
	void Start () {
		Messenger.AddListener ("endDialog",onEndDialog);
	}
	
	// Update is called once per frame
	void Update () {
		if (moveOffScreen == true) {
			Vector3 pos = gameObject.transform.position;
			gameObject.transform.position = new Vector3 (pos.x + (speed * Time.deltaTime), pos.y, pos.z);
		}
	}

	void onEndDialog(){
		moveOffScreen = true;
	}
}

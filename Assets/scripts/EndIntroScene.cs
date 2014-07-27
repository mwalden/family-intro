using UnityEngine;
using System.Collections;

public class EndIntroScene : MonoBehaviour {
	public float speed = 0.0f;
	public bool moveOffScreen;
	public float xToStartNewLevel;
	// Use this for initialization
	void Start () {
		Messenger.AddListener ("endDialog",onEndDialog);
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveOffScreen == true) {
			Vector3 pos = gameObject.transform.position;

			gameObject.transform.position = new Vector3 (pos.x + (speed * Time.deltaTime), pos.y, pos.z);
			if (pos.x >= xToStartNewLevel){
				Messenger.Broadcast("fadeOut");
			}
		}

	}
	void onEndDialog(){
		moveOffScreen = true;

	}
}

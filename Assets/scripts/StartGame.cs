using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public GUIText startText;
	public GUIText pressStartText;
	public float blinkRate;
	private bool _showing = true;
	public float previousTime;
	private bool lockInput;
	
	// Update is called once per frame
	void Start(){
		previousTime = blinkRate;
	}

	void Update () {
		if (_showing == true) {
			previousTime -= Time.deltaTime;
			if (previousTime < 0){
				previousTime = blinkRate;
				pressStartText.enabled = !pressStartText.enabled;
			}
		}

		if (lockInput == false && Input.GetAxis("Jump") > 0){
			Messenger.Broadcast ("startGame");
			_showing = false;
			startText.enabled = false;
			lockInput = true;
			pressStartText.enabled = false;
		}
	}
}

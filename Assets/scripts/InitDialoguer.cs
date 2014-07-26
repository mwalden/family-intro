using UnityEngine;
using System.Collections;

public class InitDialoguer : MonoBehaviour {
	public float timeBeforeStart;
	public int dialogId;
	private bool _startDialog = false;
	void Awake(){
		Debug.Log ("awake");
		Dialoguer.Initialize ();
	}

	void Start(){
		Dialoguer.StartDialogue(0);
		Messenger.AddListener ("startGameDialog",onStartGameDialog);
		Debug.Log ("startGameDialog added");
	}

	void Update(){
		if (_startDialog) {
			if (timeBeforeStart > 0){
				timeBeforeStart -= Time.deltaTime;
			}else{
				Dialoguer.StartDialogue(dialogId);
				_startDialog = false;
			}
		}
	}

	void onStartGameDialog(){
		_startDialog = true;
	}
	

}

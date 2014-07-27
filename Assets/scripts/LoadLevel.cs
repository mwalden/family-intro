using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Messenger<int>.AddListener ("loadLevel",onLoadLevel);
	
	}
	void onLoadLevel(int level){
		Application.LoadLevel (level);
	}


}

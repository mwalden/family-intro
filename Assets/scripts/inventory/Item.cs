using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public int id;
	public string name;
	private bool displayName; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Input.GetMouseButtonUp (0));
		if (displayName == true && Input.GetMouseButtonUp (0)) {
			Messenger<int,string>.Broadcast("onAddItem",id,name);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		displayName = true;
	}
	void OnTriggerExit2D(Collider2D other){
		displayName = false;
	}

	void OnGUI(){
		if (displayName == false)
			return;

		Vector2 screenPos = Camera.main.WorldToScreenPoint (new Vector3 (transform.position.x, gameObject.renderer.bounds.max.y,transform.position.z));
		Rect box = new Rect (screenPos.x, Screen.height-screenPos.y - gameObject.renderer.bounds.max.y, 100, 50);
//		box = GUIUtility.ScreenToGUIRect (box);
//		Debug.Log ();
		GUI.Label(box,name);

	}
}

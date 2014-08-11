using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public int id;
	public string name;
	private bool displayName; 
	public ITEMTYPE itemType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (displayName == true && Input.GetMouseButtonUp (0)) {
			Messenger<int,ITEMTYPE>.Broadcast("onItemClicked",id,itemType);
			//Messenger<int,string>.Broadcast("onAddItem",id,name);
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

		GUI.Label(box,name);

	}
}

public enum ITEMTYPE{
	DIALOG=1,
	INVENTORY=2
}

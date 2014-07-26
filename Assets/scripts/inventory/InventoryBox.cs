using UnityEngine;
using System.Collections;

public class InventoryBox : MonoBehaviour {

	public string name;
	public int id;
	public Sprite image;
	public string item;
	public string border = "inventory_border";
	private int height = 50;
	private int width = 50;
	public GUISkin skin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUI.skin = skin;
		Rect box = new Rect (gameObject.transform.position.x, gameObject.transform.position.y, 50, 50);
		GUI.depth = 30;
		Debug.Log (GUI.color);

//		GUI.Box (box, string.Empty, skin.GetStyle(border));
		GUI.depth = 20;
		GUI.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if (GUI.Button (box, name, skin.GetStyle (item))) {
			Messenger<int>.Broadcast("onItemClicked",id);
		}
//		GUI.Box (box,string.Empty,);
		GUI.color = Color.white;
//		GUI.depth = 10;
//		GUI.Label (box, name);

	}

}
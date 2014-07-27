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
		Rect box = new Rect (gameObject.transform.position.x, gameObject.transform.position.y, width, height);
		GUI.depth = 30;
		Debug.Log (GUI.color);

		GUI.depth = 20;
		GUI.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if (GUI.Button (box, name, skin.GetStyle (item))) {
			Messenger<int>.Broadcast("onItemClicked",id);
		}
		GUI.color = Color.white;

	}

}
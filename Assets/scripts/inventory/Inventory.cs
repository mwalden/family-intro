using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {
	private bool _showInventory;
	public InventoryBox inventoryBox;
	public List<InventoryBox> items;
	public GUISkin skin;
	private int h = 0;
	private int w = 0;
	private int ix = 55;
	private int iy = 0;

	public int idToRemove = -1;
	
	// Use this for initialization
	void Start () {
		items = new List<InventoryBox> ();
		Messenger<int>.AddListener ("onItemClicked", onItemClicked);
	}

	public void onItemClicked(int id){
		removeItem (id);
	}

	public void addItem(int id){
		InventoryBox iBox = Instantiate (inventoryBox, new Vector3 (ix*(items.Count+1), Screen.height - 65f, 0f), Quaternion.identity) as InventoryBox;	
		iBox.name = "test" + items.Count;
		iBox.id = id;
		iBox.item = (items.Count % 2 == 0) ? "bear" : "lighter";
		items.Add (iBox);
	}

	public void removeItem(int id){

		InventoryBox box = null;
		for (int i = 0; i < items.Count; i++) {
			box = items[i];
			if (box.id == id)
				break;
		}
		items.RemoveAt (items.IndexOf (box));

		Destroy(box);

		reorderItems ();

	}

	private void reorderItems(){
		InventoryBox box = null;
		for (int i = 0; i < items.Count;i++){
			box = items[i];
			box.transform.position = new Vector3 (ix*(i+1), Screen.height - 65f, 0f);
		}
		idToRemove = -1;
		Debug.Log ("done reordering");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			foreach(InventoryBox i in items){
				i.enabled = !i.enabled;
			}
			_showInventory = !_showInventory;
		}
		if (Input.GetKeyDown("space")) {
			addItem (Random.Range(0,1000));
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			removeItem (0);
		}

	}

	
	void OnGUI(){
		if (!_showInventory) {
			return;
		}
		GUI.skin = skin;
		GUI.depth = 100;
		float rectX = Screen.width * 0.5f;
		float rectY = Screen.height - 40;
		float rectWidth = Screen.width - 25;
		float rectHeight = 60;

		Rect dialogueBoxRect = centerRect(new Rect(rectX, rectY, rectWidth, rectHeight));
		//ground background
		GUI.color = Color.black;
		GUI.Box (dialogueBoxRect, string.Empty);
		GUI.color = Color.white;
		GUI.Label(new Rect(Screen.width-100,Screen.height-35,100,rectY),"X to close");


	}
	
	private Rect centerRect(Rect rect){
		return new Rect(rect.x - (rect.width*0.5f), rect.y - (rect.height*0.5f), rect.width, rect.height);
	}
}


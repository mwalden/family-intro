using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Messenger<int,ITEMTYPE>.AddListener ("onItemClicked", onItemClicked);
		Messenger.AddListener ("endDialog", endDialog);
		Dialoguer.Initialize ();
	}
	
	void onItemClicked(int id, ITEMTYPE itemType){
		if (itemType == ITEMTYPE.DIALOG) {
			Dialoguer.StartDialogue(id);
		}
		if (itemType == ITEMTYPE.INVENTORY) {
			Messenger<int,string>.Broadcast("onAddItem",id,name);
		}
	}

	void endDialog(){
	}
}

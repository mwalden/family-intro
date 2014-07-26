using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
	public Transform destination;
	public float speed;
	private float camHorizontalExtend;
	private float camBottomEdge;
	private bool _move = false;
	private float edgeTop;
	public string messageToBroadcastWhenDone; 
	// Use this for initialization
	void Start () {
		Messenger.AddListener ("startGame", onGameStart);
		Camera cam = Camera.main;
		float camHorizontalExtend = cam.orthographicSize * Screen.width/Screen.height;
		SpriteRenderer sRenderer = destination.GetComponent<SpriteRenderer>();
		float spriteHeight = sRenderer.renderer.bounds.size.y;
		edgeTop = (destination.position.y + spriteHeight/2) + camHorizontalExtend;
		Debug.Log (edgeTop);
	}
	
	// Update is called once per frame
	void Update () {
		if (_move == true) {

			if (this.transform.position.y > -21.6) {
			
				Vector3 pos = this.transform.position;
				this.transform.position = new Vector3 (pos.x, (pos.y - (speed * Time.deltaTime)), pos.z);
			}else{
				if (messageToBroadcastWhenDone != null)
					Messenger.Broadcast(messageToBroadcastWhenDone);
				_move = false;	
			}
		}
	}

	void onGameStart(){

		_move = true;
	}

}

using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	public float maxY;
	public float minY;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			this.transform.position = new Vector3(this.transform.position.x - (speed * Time.deltaTime), this.transform.position.y,this.transform.position.z);
			this.transform.rotation = new Quaternion(transform.rotation.x, 0f, transform.rotation.z,transform.rotation.w);

		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			this.transform.position = new Vector3(this.transform.position.x + (speed * Time.deltaTime), this.transform.position.y,this.transform.position.z);
			this.transform.rotation = new Quaternion(transform.rotation.x,180f, transform.rotation.z,transform.rotation.w);
		}

		if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < maxY){
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (speed * Time.deltaTime),this.transform.position.z);
		}

		
		if((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > minY){
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (speed * Time.deltaTime),this.transform.position.z);
		}
	}

}

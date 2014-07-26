using UnityEngine;
using System.Collections;

public class Bump : MonoBehaviour {
	public bool bump;
	public bool bumpUp;
	public float Yprev = 0.0f;
	public float yVal = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float bumpValue = Random.Range (0, 11);
		yVal = transform.position.y;
		if (bump == false && bumpValue > 9) {
			bump = true;
			bumpUp = true;
		}
		if (bump == true) {
			if (bumpUp == true){
				Yprev = transform.position.y;
				yVal += .1f;				
				bumpUp = false;
			}else{
				Debug.Log("bumpUp is false");
				yVal -= .1f;
				bump = false;
			}
		}
		transform.position = new Vector3 (transform.position.x, yVal, transform.position.z);
	}
}

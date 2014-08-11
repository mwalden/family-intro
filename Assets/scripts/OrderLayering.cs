using UnityEngine;
using System.Collections;

public class OrderLayering : MonoBehaviour {
	public Transform t;
	public int layeringOffset;
	public bool pause;
	void Update () {
		if (!pause)
			t.renderer.sortingOrder = layeringOffset - Mathf.RoundToInt(t.position.y);		
	}
}

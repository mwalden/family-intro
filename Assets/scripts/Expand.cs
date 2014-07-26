using UnityEngine;
using System.Collections;

public class Expand : MonoBehaviour {
	public tk2dTextMesh text;
	public float scaleX = 30;
	public float scaleY = 30;
	public string showText = "this is a test";
	private int numberOfCharacters = 0;
	private float lastUpdate = 0.0f;
	public float timeBetweenCharacters = 0.0f;
	private int currentCharacter = 0;
	// Use this for initialization
	void Start () {
		text = GetComponent<tk2dTextMesh>();
		scaleX = 0;
		scaleY = 0;
		numberOfCharacters = showText.Length;
		lastUpdate = timeBetweenCharacters;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCharacter < numberOfCharacters) {
			lastUpdate -= Time.deltaTime;
			if (lastUpdate < 0) {
				text.text += showText [currentCharacter];
				currentCharacter++;
				lastUpdate = timeBetweenCharacters;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class NPCFollow : MonoBehaviour {
	public Coordinate[] coordinates;
	public float speed;
	public float timeBetweenMovements;

	private float countDownToMove;
	private bool moving;
	private Vector3 lastPosition;
	private Vector3 newPosition;
	private float journeyLength;
	public int currentStep;
	private float startTime;
	// Use this for initialization
	void Start () {
		countDownToMove = timeBetweenMovements;
	}
	
	// Update is called once per frame
	void Update () {
		countDownToMove -= Time.deltaTime;
		if (currentStep == coordinates.Length)
			return;
		if (countDownToMove <= 0 && !moving){
			moving = true;
			lastPosition = transform.position;
			newPosition = new Vector3(coordinates[currentStep].x, coordinates[currentStep].y,transform.position.z);
			journeyLength = Vector3.Distance(lastPosition, newPosition);
			startTime = Time.time;
			if (lastPosition.x < newPosition.x){
				transform.rotation = new Quaternion(transform.rotation.x,0.0f,transform.rotation.z,transform.rotation.w);
			}
			if (lastPosition.x >= newPosition.x){
				transform.rotation = new Quaternion(transform.rotation.x,180.0f,transform.rotation.z,transform.rotation.w);
			}
		}

		if (moving == true) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(lastPosition, newPosition, fracJourney);
		}
		if (moving == true && transform.position.x == newPosition.x && transform.position.y == newPosition.y) {
			moving = false;
			currentStep++;
			countDownToMove = timeBetweenMovements;
		}
	}
	

}
[System.Serializable]
public class Coordinate : PropertyAttribute{
	public float x;
	public float y;
}


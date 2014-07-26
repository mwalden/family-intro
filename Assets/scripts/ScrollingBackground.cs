using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public enum DIRECTION
		{
			LEFT,
			RIGHT
		}
	public GameObject myTransform;
	private GameObject[] backgrounds;
	private Camera mainCamera;
	public int count;
	public float speed;
	public bool invertImages;
	public ScrollingBackground.DIRECTION direction;
	public float offset;

	private Vector3 previous;
	// Use this for initialization
	void Start () {
		mainCamera =  Camera.main;
		previous = mainCamera.transform.position;
		float bgSize = myTransform.renderer.bounds.size.x;
		backgrounds = new GameObject[count];
		for (int i = 0; i < count; i++) {
			Vector3 pos = new Vector3(myTransform.transform.position.x + bgSize * i,transform.position.y,0.0f);
			Quaternion rotation = myTransform.transform.rotation;
			if (invertImages == true && i % 2 == 0){
				rotation = new Quaternion(0.0f,180.0f,0.0f,0.0f);
			}

			GameObject newBuddy = Instantiate (myTransform, pos, rotation ) as GameObject;
			backgrounds[i] = newBuddy;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (previous.x != mainCamera.transform.position.x) {
			direction = previous.x <= mainCamera.transform.position.x ? DIRECTION.RIGHT : DIRECTION.LEFT;
			previous = mainCamera.transform.position;
		}
		for (int i = 0; i< backgrounds.Length; i++) {

			GameObject background = backgrounds [i];

			Vector3 bgPos = background.transform.position;
			Vector3 cameraPos = mainCamera.gameObject.transform.position;
			float bgSize = background.renderer.bounds.size.x;
			float camHorizontalExtend = mainCamera.orthographicSize * Screen.width / Screen.height;

			//going right
			if (direction == DIRECTION.RIGHT) {
				if (bgPos.x + bgSize < cameraPos.x + offset) {
					background.transform.position = new Vector3 ((bgSize * (backgrounds.Length)) + bgPos.x, bgPos.y, bgPos.z);
				}else{
					background.transform.position = new Vector3 (bgPos.x - speed * Time.deltaTime, bgPos.y, bgPos.z);
				}
			}

			if (direction == DIRECTION.LEFT){
				if (bgPos.x > cameraPos.x + bgSize) {

					background.transform.position = new Vector3(cameraPos.x - bgSize,bgPos.y,bgPos.z);
				}else{
					background.transform.position = new Vector3 (bgPos.x + speed * Time.deltaTime, bgPos.y, bgPos.z);
				}
			}
		}
	}

}
	
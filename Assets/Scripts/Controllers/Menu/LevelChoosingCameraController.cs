using UnityEngine;
using System.Collections;

public class LevelChoosingCameraController : MonoBehaviour {

	private InputService inputService = Singleton<InputService>.GetInstance();
	private const float CAMERA_MOVING_POWER = 10;

	public GameObject buttonUp;
	public GameObject buttonDown;
	public GameObject buttonBack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		moveCamera ();
	}

	private void moveCamera() {

		if (inputService.IsInputHold()) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider == null) { return; }

			if (hit.collider.gameObject.Equals (buttonUp)) { 

				this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, CAMERA_MOVING_POWER));
			
			} else if (hit.collider.gameObject.Equals (buttonDown)) {
				
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -CAMERA_MOVING_POWER));
			}
		}
	}
}

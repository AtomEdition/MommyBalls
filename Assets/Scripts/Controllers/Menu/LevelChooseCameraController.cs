using UnityEngine;
using System.Collections;

public class LevelChooseCameraController : MonoBehaviour {

	private InputService inputService = Singleton<InputService>.GetInstance();
	private const float CAMERA_MOVING_POWER = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		
		moveCamera ();
	}

	private void moveCamera() {

		if (inputService.IsInputHold()) {

			this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, CAMERA_MOVING_POWER));
		}
	}
}

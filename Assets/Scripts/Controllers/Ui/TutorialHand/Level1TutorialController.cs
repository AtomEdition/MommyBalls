using UnityEngine;
using System.Collections;

public class Level1TutorialController : MonoBehaviour {

	private const float BORDER_Y = -2.8F;
	private Vector3 START_POSITION;

	void Start() {

		START_POSITION = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {
	
		if (transform.position.y > BORDER_Y) {

			transform.position = START_POSITION;
		}
	}
}

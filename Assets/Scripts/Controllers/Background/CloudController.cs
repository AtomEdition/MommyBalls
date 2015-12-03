using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	private const float OUT_OF_LEVEL_RANGE = 8F;	

	// Update is called once per frame
	void Update () {

		CheckCloudPosition ();
	}

	private void CheckCloudPosition() {
		if (transform.position.x > OUT_OF_LEVEL_RANGE
			|| transform.position.x < -OUT_OF_LEVEL_RANGE) {

			Vector2 oldVector = gameObject.transform.position;
			Vector2 newVector = new Vector2 (-oldVector.x, oldVector.y);
			transform.position = newVector;
		}
	}
}

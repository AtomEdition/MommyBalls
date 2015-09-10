using UnityEngine;
using System.Collections;

public class JumperBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball") {

			//this.gameObject.transform.rotation.z;
			collision.gameObject.GetComponent<Rigidbody2D>()
				.AddForce (new Vector3 (0 , JumperProperties.JUMPER_VERTICAL_POWER));

		}
	}

	int getQuaterByAngle(int angle) {

		return (angle > 180 && angle <= 270)
				? (angle > 90 && angle <= 180)
				? (angle > 0 && angle <= 90)
				? 1
				: 2
				: 3
				: 4;
	}

	int getSignForPowerX(int quater) {
		switch (quater) {
		case 1:
			return 1;
		case 2:
			return -1;
		case 3:
			return -1;
		case 4:
			return 1;
		}
		return 0;
	}
	
	int getSignForPowerY(int quater) {
		switch (quater) {
		case 1:
			return 1;
		case 2:
			return 1;
		case 3:
			return -1;
		case 4:
			return -1;
		}
		return 0;
	}
}

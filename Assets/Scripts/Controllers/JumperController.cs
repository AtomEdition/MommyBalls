using UnityEngine;
using System.Collections;

public class JumperController : MonoBehaviour {

	public int jumperPowerMode = 0;
	private int chosenJumperPower;

	// Use this for initialization
	void Start () {

		chosenJumperPower = choseJumperPowerByMode (jumperPowerMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private int choseJumperPowerByMode(int powerMode) {

		switch (powerMode) {
		case 1:
			return JumperProperties.JUMPER_POWER_LOW;
		case 2:
			return JumperProperties.JUMPER_POWER_MEDIUM;
		case 3:
			return JumperProperties.JUMPER_POWER_HIGH;
		}

		return 0;
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball") {
			
			float jumperAngle = this.gameObject.transform.eulerAngles.z;

			float powerX = getPowerMultiplierX(jumperAngle) * chosenJumperPower;
			float powerY = getPowerMultiplierY(jumperAngle) * chosenJumperPower;

			collision.gameObject.GetComponent<Rigidbody2D>()
				.AddForce (new Vector3 (powerX , powerY));
		}
	}

	float getPowerMultiplierX(float angle) {

		float angleInRad = Mathf.Deg2Rad * angle;
		return Mathf.Cos (angleInRad);
	}
	
	float getPowerMultiplierY(float angle) {
		
		float angleInRad = Mathf.Deg2Rad * angle;
		return Mathf.Sin (angleInRad);
	}
}

using UnityEngine;
using System.Collections;

public class BlowerController : MonoBehaviour {

	public float powerMultiplier = 1;
	private const int BASE_BLOWER_POWER = 10;
	private float currentBlowerPower;

	void Start(){
	
		currentBlowerPower = BASE_BLOWER_POWER * powerMultiplier;
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
	}

	void OnTriggerStay2D(Collider2D trigger){
		
		if (trigger.gameObject.tag == Tags.BALL) {
			
			float blowerAngle = this.gameObject.transform.eulerAngles.z;
			
			float powerX = GetPowerMultiplierX(blowerAngle) * currentBlowerPower;
			float powerY = GetPowerMultiplierY(blowerAngle) * currentBlowerPower;
			
			trigger.gameObject.GetComponent<Rigidbody2D>()
				.AddForce (new Vector3 (powerX , powerY));		

		}
	}	
	
	private float GetPowerMultiplierX(float angle) {
		
		float angleInRad = Mathf.Deg2Rad * angle;
		return Mathf.Cos (angleInRad);
	}
	
	private float GetPowerMultiplierY(float angle) {
		
		float angleInRad = Mathf.Deg2Rad * angle;
		return Mathf.Sin (angleInRad);
	}
}

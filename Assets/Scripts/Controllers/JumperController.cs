using UnityEngine;
using System.Collections;

public class JumperController : MonoBehaviour {

	private const int JUMPER_POWER = 300;

	public int jumperPowerMultiplier = 0;
	private int chosenJumperPower;

	// Use this for initialization
	void Start () {

		chosenJumperPower = JUMPER_POWER * jumperPowerMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball") {
			
			float jumperAngle = this.gameObject.transform.eulerAngles.z;

			collision.gameObject.GetComponent<Rigidbody2D>()
				.AddForce (GetForceVector(jumperAngle, chosenJumperPower));
		}
	}

	private Vector2 GetForceVector(float jumperAngle, float jumperPower) {
		
		float angleInRad = Mathf.Deg2Rad * jumperAngle;

		float powerX = Mathf.Cos (angleInRad) * jumperPower;
		float powerY = Mathf.Sin (angleInRad) * jumperPower;

		return new Vector2 (powerX, powerY);
	}
}

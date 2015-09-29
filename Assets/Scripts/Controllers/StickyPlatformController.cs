using UnityEngine;
using System.Collections;

public class StickyPlatformController : MonoBehaviour {

	private InputService inputService = Singleton<InputService>.GetInstance();

	private const float PLATFORM_POWER_BASE = 1000;
	public float platformPowerMultiplier = 1;
	public float delaySecondsMaximum = 1;
	private float platformPowerCurrent;

	private bool isCharging = false;

	// Use this for initialization
	void Start () {
	
		platformPowerCurrent = PLATFORM_POWER_BASE * platformPowerMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter2D (Collider2D collision) {
		
		if (collision.gameObject.tag == Tags.BALL) {

			Rigidbody2D rBody = collision.gameObject.GetComponent<Rigidbody2D>();
			rBody.constraints = RigidbodyConstraints2D.FreezeAll;
			collision.gameObject.transform.parent = this.gameObject.transform;

			collision.gameObject.GetComponent<BallController>().IsSafeColliding = true;
		}
	}

	/// <summary>
	/// Raises the collision stay2 d event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerStay2D (Collider2D collision) {

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		
		if (inputService.IsInputDown()
		    && hit.collider != null
		    && hit.collider.gameObject.tag == Tags.STICKY_PLATFORM) {
		
			isCharging = true;

		} else if (inputService.IsInputUp()
		           && (hit.collider != null
		           && hit.collider.gameObject == this.gameObject
		           || isCharging)) {
			
			platformPowerCurrent *= inputService.GetTimeOfClick() > delaySecondsMaximum 
				? delaySecondsMaximum : inputService.GetTimeOfClick();

			collision.gameObject.transform.parent = null;
			Rigidbody2D rBody = collision.gameObject.GetComponent<Rigidbody2D>();
			rBody.constraints = RigidbodyConstraints2D.None;
			rBody.AddForce(GetForceVector(this.gameObject.transform.eulerAngles.z, platformPowerCurrent));

			platformPowerCurrent = PLATFORM_POWER_BASE * platformPowerMultiplier;
			isCharging = false;

			collision.gameObject.GetComponent<BallController>().IsSafeColliding = false;
		}

	}

	/// <summary>
	/// Gets the force vector.
	/// </summary>
	/// <returns>The force vector.</returns>
	/// <param name="platformAngle">Platform angle.</param>
	/// <param name="platformPower">Platform power.</param>
	private Vector2 GetForceVector(float platformAngle, float platformPower) {
		
		float angleInRad = Mathf.Deg2Rad * platformAngle;
		
		float powerX = Mathf.Cos (angleInRad) * platformPower;
		float powerY = Mathf.Sin (angleInRad) * platformPower;
		
		return new Vector2 (powerX, powerY);
	}
}

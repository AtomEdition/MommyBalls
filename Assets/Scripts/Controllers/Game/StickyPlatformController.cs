﻿using UnityEngine;
using System.Collections;

public class StickyPlatformController : MonoBehaviour {
	
	public GameObject fireButton;

	private readonly InputService inputService = Singleton<InputService>.GetInstance();

	private const float PLATFORM_POWER_BASE = 1000;
	public float platformPowerMultiplier = 1;
	public float delaySecondsMaximum = 1;
	private float platformPowerCurrent;

	private bool isCharging;

	private readonly LevelService levelService = Singleton<LevelService>.GetInstance();
	public CustomEvent onBallCollide = new CustomEvent();
	public CustomEvent onBallCharging = new CustomEvent();
	public CustomEvent onBallRelease = new CustomEvent();

	// Use this for initialization
	void Start () {
	
		platformPowerCurrent = PLATFORM_POWER_BASE * platformPowerMultiplier;
	}

	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter2D (Collider2D collision) {
		
		if (collision.gameObject.tag == Tags.BALL) {

			Rigidbody2D rBody = collision.gameObject.GetComponent<Rigidbody2D>();
			rBody.constraints = RigidbodyConstraints2D.FreezeAll;

			collision.gameObject.GetComponent<BallController>().IsSafeColliding = true;
			collision.gameObject.transform.SetParent (this.gameObject.transform);

			onBallCollide.Call ();
			levelService.OnBallStick.Call ();
			collision.gameObject.GetComponent<BallController>().OnGrounded.Call ();
		}
	}

	/// <summary>
	/// Raises the collision stay2 d event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerStay2D (Collider2D collision) {

		if (inputService.IsInputDown ()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
			if (hit.collider != null
			    && fireButton.Equals(hit.collider.gameObject)) {
				
				isCharging = true;
				onBallCharging.Call ();
			}
		}		
		
		if (inputService.IsInputUp()) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		    
			if (hit.collider != null
			    && fireButton.Equals (hit.collider.gameObject)
			    || isCharging) {
				
				platformPowerCurrent *= inputService.GetTimeOfClick() > delaySecondsMaximum 
					? delaySecondsMaximum : inputService.GetTimeOfClick();
				
				collision.gameObject.transform.parent = null;
				Rigidbody2D rBody = collision.gameObject.GetComponent<Rigidbody2D>();
				rBody.constraints = RigidbodyConstraints2D.None;
				rBody.AddForce(GetForceVector(this.gameObject.transform.eulerAngles.z, platformPowerCurrent));
				
				platformPowerCurrent = PLATFORM_POWER_BASE * platformPowerMultiplier;
				isCharging = false;
				
				collision.gameObject.GetComponent<BallController>().IsSafeColliding = false;

				collision.gameObject.GetComponent<BallController>().OnReleased.Call();
				onBallRelease.Call ();
				levelService.OnBallRelease.Call ();
			}
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

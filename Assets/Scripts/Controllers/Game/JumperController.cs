﻿using UnityEngine;
using System.Collections;

public class JumperController : MonoBehaviour {

	private const int JUMPER_POWER = 400;

	public float jumperPowerMultiplier = 1;
	private float chosenJumperPower;
	
	public CustomEvent onBallCollide = new CustomEvent();

	// Use this for initialization
	void Start () {

		chosenJumperPower = JUMPER_POWER * jumperPowerMultiplier;
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == Tags.BALL) {
			
			float jumperAngle = this.gameObject.transform.eulerAngles.z;

			collision.gameObject.GetComponent<Rigidbody2D>()
				.AddForce (GetForceVector(jumperAngle, chosenJumperPower));
			onBallCollide.Call();
		}
	}

	private Vector2 GetForceVector(float jumperAngle, float jumperPower) {
		
		float angleInRad = Mathf.Deg2Rad * jumperAngle;

		float powerX = Mathf.Cos (angleInRad) * jumperPower;
		float powerY = Mathf.Sin (angleInRad) * jumperPower;

		return new Vector2 (powerX, powerY);
	}
}

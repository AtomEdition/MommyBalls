using UnityEngine;
using System.Collections;

public class StickyPlatformAppearance : MonoBehaviour {
	
	private const string ACTION_ANIMATION_TAG = "Action";
	private const string CHARGE_ANIMATION_TAG = "Charge";
	
	// Use this for initialization
	void Start () {
		
		GetComponent<StickyPlatformController> ().onBallCharging.eventAttachTo += SetChargeAnimation;
		GetComponent<StickyPlatformController> ().onBallRelease.eventAttachTo += SetActionAnimation;
	}
	
	private void SetActionAnimation() {
		
		GetComponentInChildren<Animator> ().SetTrigger (ACTION_ANIMATION_TAG);
	}
	
	private void SetChargeAnimation() {
		
		GetComponentInChildren<Animator> ().SetTrigger (CHARGE_ANIMATION_TAG);
	}
}

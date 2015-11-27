using UnityEngine;
using System.Collections;

public class StickyPlatformAppearance : MonoBehaviour {
	
	private const string ACTION_ANIMATION_TAG = "Action";
	
	// Use this for initialization
	void Start () {
		
		GetComponent<StickyPlatformController> ().onBallRelease.eventAttachTo += SetAnimation;
	}
	
	private void SetAnimation() {
		
		GetComponentInChildren<Animator> ().SetTrigger (ACTION_ANIMATION_TAG);
	}
}

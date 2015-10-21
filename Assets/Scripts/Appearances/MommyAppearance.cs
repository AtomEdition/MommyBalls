using UnityEngine;
using System.Collections;

public class MommyAppearance : Appearance {
	
	private const string IDLE_ANIMATION_TAG = "Idle";
	private const string DIE_ANIMATION_TAG = "Sad";
	private const string CATCH_ANIMATION_TAG = "Happy";
	private const float APPEARANCE_SIZE_MULTIPLIER = 0.8F;

	public GameObject animationPrefab;

	LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
		AttachAnimation ();
		levelService.OnBallCreate.eventAttachTo += SetIdleAnimation;
		levelService.OnBallCatch.eventAttachTo += SetCatchedAnimation;
		levelService.OnBallDestroy.eventAttachTo += SetDieAnimation;
	}	

	private void AttachAnimation() {

		GameObject newBallAppearance = Instantiate (animationPrefab) as GameObject;

		Vector3 vec = gameObject.transform.localScale;
		newBallAppearance.transform.localScale = new Vector3(vec.x, vec.y) * APPEARANCE_SIZE_MULTIPLIER;

		newBallAppearance.transform.position = gameObject.transform.position;
		newBallAppearance.transform.parent = gameObject.transform;
	}
		
	private void SetIdleAnimation() {

		this.GetComponentInChildren<Animator> ().SetTrigger (IDLE_ANIMATION_TAG);
	}

	private void SetDieAnimation() {

		this.GetComponentInChildren<Animator> ().SetTrigger (DIE_ANIMATION_TAG);
	}

	private void SetCatchedAnimation() {

		this.GetComponentInChildren<Animator> ().SetTrigger (CATCH_ANIMATION_TAG);
	}
}

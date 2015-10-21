using UnityEngine;
using System.Collections;

public class BallAppearance : Appearance {

	private const string FLY_ANIMATION_TAG = "Fly";
	private const string IDLE_ANIMATION_TAG = "Idle";
	private const float APPEARANCE_SIZE_MULTIPLIER = 1.3F;

	public GameObject[] animationPrefabs;
	public Material[] materials;

	LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
			
		AttachAnimation ();
		levelService.OnBallCreate.eventAttachTo += this.SetIdleAnimation;
		levelService.OnBallGrounded.eventAttachTo += this.SetIdleAnimation;
		levelService.OnBallRelease.eventAttachTo += this.SetFlyingAnimation;
		levelService.OnBallDestroy.eventAttachTo += this.UnattachMethods;
	}

	private void AttachAnimation() {

		int index = Random.Range(0, animationPrefabs.Length);
		GameObject newBallAppearance = Instantiate (animationPrefabs[index]) as GameObject;

		newBallAppearance.transform.position = gameObject.transform.position;
		newBallAppearance.transform.parent = gameObject.transform;

		Vector3 vec = gameObject.transform.localScale;
		newBallAppearance.transform.localScale = new Vector3(vec.x, vec.y) * APPEARANCE_SIZE_MULTIPLIER;

		AttachMaterial (newBallAppearance);
	}

	private void AttachMaterial(GameObject ball) {

		SpriteRenderer[] array = ball.GetComponentsInChildren<SpriteRenderer> ();

		foreach (SpriteRenderer sr in array) {

			if (Tags.BALL_BACKGROUND.Equals (sr.gameObject.tag)) {
				
				int index = Random.Range(0, materials.Length);
				sr.material = materials[index];
			}
		}
	}

	private void SetIdleAnimation() {

		this.GetComponentInChildren<Animator> ().SetTrigger (IDLE_ANIMATION_TAG);
	}
	
	private void SetFlyingAnimation() {

		this.GetComponentInChildren<Animator> ().SetTrigger (FLY_ANIMATION_TAG);
	}
	
	private void UnattachMethods() {
		
		levelService.OnBallCreate.eventAttachTo -= this.SetIdleAnimation;
		levelService.OnBallGrounded.eventAttachTo -= this.SetIdleAnimation;
		levelService.OnBallRelease.eventAttachTo -= this.SetFlyingAnimation;
		levelService.OnBallDestroy.eventAttachTo += this.UnattachMethods;
	}
}

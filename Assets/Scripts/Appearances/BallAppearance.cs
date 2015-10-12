using UnityEngine;
using System.Collections;

public class BallAppearance : MonoBehaviour {

	private const string FLY_ANIMATION_TAG = "Fly";
	private const string IDLE_ANIMATION_TAG = "Idle";

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

		newBallAppearance.transform.position = this.gameObject.transform.position;
		newBallAppearance.transform.parent = this.gameObject.transform;

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

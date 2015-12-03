using UnityEngine;
using System.Collections;

public class BallAppearance : Appearance {

	private const string FLY_ANIMATION_TAG = "Fly";
	private const string IDLE_ANIMATION_TAG = "Idle";
	private const float APPEARANCE_SIZE_MULTIPLIER = 1.3F;

	public GameObject[] animationPrefabs;
	public Material[] materials;

	private GameObject currentAppearance;

	readonly LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
			
		gameObject.GetComponent<BallController>().OnCreated.eventAttachTo += SetIdleAnimation;
		gameObject.GetComponent<BallController>().OnGrounded.eventAttachTo += SetIdleAnimation;
		gameObject.GetComponent<BallController>().OnReleased.eventAttachTo += SetFlyingAnimation;
		levelService.OnAfterBallDestroy.eventAttachTo += UnattachMethods;
	}

	public void AttachAnimation() {

		int index = Random.Range(0, animationPrefabs.Length);
		currentAppearance = Instantiate (animationPrefabs[index]) as GameObject;
		
		currentAppearance.transform.position = gameObject.transform.position;
		currentAppearance.transform.parent = gameObject.transform;
		
		Vector3 vec = gameObject.transform.localScale;
		currentAppearance.transform.localScale = new Vector3(vec.x, vec.y) * APPEARANCE_SIZE_MULTIPLIER;

		AttachMaterial (currentAppearance);
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
	
	public void SetFlyingAnimation() {

		this.GetComponentInChildren<Animator> ().SetTrigger (FLY_ANIMATION_TAG);
	}
	
	private void UnattachMethods() {
		
		gameObject.GetComponent<BallController>().OnCreated.eventAttachTo -= SetIdleAnimation;
		gameObject.GetComponent<BallController>().OnGrounded.eventAttachTo -= SetIdleAnimation;
		gameObject.GetComponent<BallController>().OnReleased.eventAttachTo -= SetFlyingAnimation;
		levelService.OnAfterBallDestroy.eventAttachTo -= UnattachMethods;
	}

	public GameObject CurrentAppearance {
		get {
			return this.currentAppearance;
		}
		set {
			this.currentAppearance = value;
		}
	}
}

using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private const float OUT_OF_LEVEL_RANGE = -8F;	
	private const float LEVEL_ENDED_DELAY = 0.5F;

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	private bool isMovingByMouse = true;
	private bool isSafeColliding = false;

	// Use this for initialization
	private void Start () {

	}

	// Update is called once per frame
	private void Update () {

		CheckDestroyCondition ();
	}

	private void CheckDestroyCondition(){	

		if (this.transform.position.y < OUT_OF_LEVEL_RANGE) {

			Destroy (this.gameObject);
		}
	}	

	public void OnDestroy() {
		
		levelService.OnBallDestroy.Call ();
	}

	public void SetBallBehaviourOnContinuousClick() {

		isMovingByMouse = true;
		this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		
		levelService.BallCount--;
		levelService.OnBallCreate.Call ();
	}
	
	public void ReleaseBall() {

		if (isMovingByMouse) {

			isMovingByMouse = false;
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (BasketClickListener.GetPowerX (), BasketClickListener.GetPowerY ()));
			levelService.OnBallRelease.Call();
		}
	}
	
	public void MoveBallToPressedPosition(Vector2 vec) {

		if (this.gameObject.GetComponent<BallController> ().isMovingByMouse) {

			float step = BallProperties.BALL_MOVE_SPEED * Time.deltaTime;
		
			this.transform.position = Vector2.MoveTowards (this.transform.position, vec, step);
		}
	}

	public bool IsSafeColliding {

		get {
			return this.isSafeColliding;
		}
		set {
			isSafeColliding = value;
		}
	}
}
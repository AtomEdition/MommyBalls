using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private const float OUT_OF_LEVEL_RANGE = -8F;
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	public delegate void MethodContainer ();
	public event MethodContainer OnBallDestroy;

	private bool isMovingByMouse = true;

	// Use this for initialization
	private void Start () {

		OnBallDestroy += levelService.CheckForLevelEnded;
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

		OnBallDestroy ();	
	}
	
	public void SetBallBehaviourOnContinuousClick() {

		isMovingByMouse = true;
		this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		
		levelService.BallCount--;
	}
	
	public void ReleaseBall() {

		if (isMovingByMouse) {

			isMovingByMouse = false;
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (BasketClickListener.GetPowerX (), BasketClickListener.GetPowerY ()));
		}
	}
	
	public void MoveBallToPressedPosition(Vector2 vec) {

		if (this.gameObject.GetComponent<BallController> ().isMovingByMouse) {

			float step = BallProperties.BALL_MOVE_SPEED * Time.deltaTime;
		
			this.transform.position = Vector2.MoveTowards (this.transform.position, vec, step);
		}
	}

}
using UnityEngine;
using System.Collections;

public class BallCreateController : MonoBehaviour {
	
	public const float BALL_MOVE_SPEED = 20F;	
	public const float BALL_POWER_MULTIPLIER = 280F;
	public const float BALL_POWER_MAXIMUM = 1000F;	

	private LevelService levelService = Singleton<LevelService>.GetInstance();
	private InputService inputService = Singleton<InputService>.GetInstance();	
	private bool isMovingByMouse = false;

	public void SetBallBehaviourOnContinuousClick() {
		
		isMovingByMouse = true;
		GetComponent<Rigidbody2D>().isKinematic = true;
		
		levelService.BallCount--;
		levelService.OnBallCreate.Call ();
		GetComponent<BallController> ().OnCreated.Call ();

		GetComponent<BallAppearance> ().AttachAnimation ();
	}
	
	public void ReleaseBall() {
		
		if (isMovingByMouse) {
			
			isMovingByMouse = false;
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (GetPowerX (), GetPowerY ()));
			levelService.OnBallRelease.Call();
			gameObject.GetComponent<BallController>().OnReleased.Call();
		}
	}	
	
	private float GetPowerX()
	{
		float powerX = inputService.GetCurrentPosition().x - transform.position.x;
		powerX *= BALL_POWER_MULTIPLIER;

		return powerX < BALL_POWER_MAXIMUM ? powerX : BALL_POWER_MAXIMUM;
	}
	
	
	private float GetPowerY()
	{
		float powerY = inputService.GetCurrentPosition().y - transform.position.y;
		powerY *= BALL_POWER_MULTIPLIER; 
		
		return powerY < BALL_POWER_MAXIMUM ? powerY	: BALL_POWER_MAXIMUM;
	}

	public void MoveBallToPressedPosition(Vector2 vec) {
		
		if (isMovingByMouse) {
			
			float step = BALL_MOVE_SPEED * Time.deltaTime;
			
			transform.position = Vector2.MoveTowards (transform.position, vec, step);
		}
	}
}

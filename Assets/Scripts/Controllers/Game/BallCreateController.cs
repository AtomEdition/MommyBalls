using UnityEngine;
using System.Collections;

public class BallCreateController : MonoBehaviour {
	
	public const float BALL_MOVE_SPEED = 30F;	
	public const float BALL_POWER_MULTIPLIER = 800F;
	public const float BALL_POWER_MAXIMUM = 1500F;	

	private readonly LevelService levelService = Singleton<LevelService>.GetInstance();
	private readonly InputService inputService = Singleton<InputService>.GetInstance();	
	private bool isMovingByMouse;

	private float currentPowerX = 0F;
	private float currentPowerY = 0F;

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
			countCurrentPower ();
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (currentPowerX, currentPowerY));
			levelService.OnBallRelease.Call();
			gameObject.GetComponent<BallController>().OnReleased.Call();
		}
	}	

	private void countCurrentPower() {

		currentPowerX = inputService.GetCurrentPosition().x - transform.position.x;
		currentPowerX *= BALL_POWER_MULTIPLIER;
		currentPowerY = inputService.GetCurrentPosition().y - transform.position.y;
		currentPowerY *= BALL_POWER_MULTIPLIER;
		if (currentPowerX > BALL_POWER_MAXIMUM && currentPowerX >= currentPowerY) {
			currentPowerY *= BALL_POWER_MAXIMUM / currentPowerX;
			currentPowerX = BALL_POWER_MAXIMUM;
		}
		else if (currentPowerY > BALL_POWER_MAXIMUM) {
			currentPowerX *= BALL_POWER_MAXIMUM / currentPowerY;
			currentPowerY = BALL_POWER_MAXIMUM;
		}
	}

	public void MoveBallToPressedPosition(Vector2 vec) {
		
		if (isMovingByMouse) {
			
			float step = BALL_MOVE_SPEED * Time.deltaTime;
			
			transform.position = Vector2.MoveTowards (transform.position, vec, step);
		}
	}
}

using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	public GameObject ball;
	private InputService inputService = Singleton<InputService>.GetInstance();
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (IsBasketClicked()) {

			Vector2 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			GameObject newBall = Instantiate (ball, new Vector2 (vec.x, vec.y), Quaternion.identity) as GameObject;
			newBall.gameObject.GetComponent<BallController>().SetBallBehaviourOnContinuousClick();
			BasketClickListener.SetNewPoints(vec.x, vec.y);
		}
	}

	public bool IsBasketClicked(){

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
		return (inputService.IsInputDown() 
		        && hit.collider != null
		        && hit.collider.gameObject == this.gameObject
		        && levelService.BallCount > 0);
	}

	void OnTriggerExit2D(Collider2D trigger){
		
		if (trigger.gameObject.tag == Tags.BALL) {

			trigger.gameObject.GetComponent<BallController>().ReleaseBall();
		}
	}

	void OnTriggerStay2D(Collider2D trigger){
		
		if (trigger.gameObject.tag == Tags.BALL) {
			
			Vector2 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			BasketClickListener.SetNewPoints(vec.x, vec.y);

			if (inputService.IsInputUp()) {

				trigger.gameObject.GetComponent<BallController>().ReleaseBall();

			} else {

				trigger.gameObject.GetComponent<BallController>().MoveBallToPressedPosition(vec);
			}
						
		}
	}
}

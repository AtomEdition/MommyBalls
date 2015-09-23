using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public GameObject mommy;
	public GameObject basket;

	public GameObject textScore;
	public GameObject textBalls;

	public int[] levelData = new int[4];

	private LevelService levelService = Singleton<LevelService>.getInstance();

	private GameObject pressedBall = null;
	private bool isBallPressed = false;

	// Use this for initialization
	void Start () {

		levelService.BallCount = levelData [0];
		levelService.ScoreStars3 = levelData [1];
		levelService.ScoreStars2 = levelData [2];
		levelService.ScoreStars1 = levelData [3];
	}
	
	// Update is called once per frame
	void Update () {
				
		if ((levelService.BallCount > 0) || (isBallPressed)) 
		{
			Vector2 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (!isBallPressed) {

				if (Input.GetMouseButtonDown (0)) 

					if (BasketController.CheckCollisionBasket())
					{
						CreateBall(vec.x, vec.y);	
						BasketClickListener.SetNewPoints(vec.x, vec.y);
					}

			} else {

				BasketClickListener.SetNewPoints(vec.x, vec.y);

				if (!Input.GetMouseButtonUp (0)) 
				{
					if (BasketController.CheckCollisionBasket())
						MoveBallToPressedPosition(vec);
					else
						ReleaseBall();
				}

				else if (Input.GetMouseButtonUp (0)) 
				{
					ReleaseBall();
				}
			}
		}

		else if (GameObject.FindGameObjectsWithTag("Ball").Length == 0) {

			Application.LoadLevel (ScoreProperties.SCREEN_NAME_LEVEL_COMPLETE);
		}

	}

	private void CreateBall(float x, float y)
	{
		pressedBall = Instantiate (ball, new Vector2 (x, y), Quaternion.identity) as GameObject;

		pressedBall.GetComponent<Collider2D>().enabled = false;		
		pressedBall.GetComponent<Rigidbody2D>().isKinematic = true;

		levelService.BallCount--;
		
		isBallPressed = true;
	}

	private void MoveBallToPressedPosition(Vector2 vec)
	{
		float step = BallProperties.BALL_MOVE_SPEED * Time.deltaTime;

		pressedBall.transform.position = Vector2.MoveTowards (pressedBall.transform.position, vec, step);
	}

	private void ReleaseBall()
	{
		pressedBall.GetComponent<Collider2D>().enabled = true;
		pressedBall.GetComponent<Rigidbody2D>().isKinematic = false;
		pressedBall.GetComponent<Rigidbody2D>().AddForce (new Vector3 (BasketClickListener.GetPowerX (), BasketClickListener.GetPowerY (), 0));
		
		isBallPressed = false;
	}

}

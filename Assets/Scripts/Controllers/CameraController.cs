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

					if (BasketController.checkCollisionBasket())
					{
						createBall(vec.x, vec.y);	
						BasketClickListener.setNewPoints(vec.x, vec.y);
					}

			} else {

				BasketClickListener.setNewPoints(vec.x, vec.y);

				if (!Input.GetMouseButtonUp (0)) 
				{
					if (BasketController.checkCollisionBasket())
						moveBallToPressedPosition(vec);
					else
						releaseBall();
				}

				else if (Input.GetMouseButtonUp (0)) 
				{
					releaseBall();
				}
			}
		}

		else if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
			Application.LoadLevel (ScoreProperties.SCREEN_NAME_LEVEL_COMPLETE);

	}

	private void createBall(float x, float y)
	{
		pressedBall = Instantiate (ball, new Vector2 (x, y), Quaternion.identity) as GameObject;

		pressedBall.GetComponent<Collider2D>().enabled = false;		
		pressedBall.GetComponent<Rigidbody2D>().isKinematic = true;

		levelService.BallCount--;
		
		isBallPressed = true;
	}

	private void moveBallToPressedPosition(Vector2 vec)
	{
		float step = BallProperties.BALL_MOVE_SPEED * Time.deltaTime;

		pressedBall.transform.position = Vector2.MoveTowards (pressedBall.transform.position, vec, step);
	}

	private void releaseBall()
	{
		pressedBall.GetComponent<Collider2D>().enabled = true;
		pressedBall.GetComponent<Rigidbody2D>().isKinematic = false;
		pressedBall.GetComponent<Rigidbody2D>().AddForce (new Vector3 (BasketClickListener.getPowerX (), BasketClickListener.getPowerY (), 0));
		
		isBallPressed = false;
	}

}

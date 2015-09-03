using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public GameObject mommy;
	public GameObject basket;

	public GameObject textScore;
	public GameObject textBalls;

	private GameObject pressedBall = null;
	private bool isBallPressed = false;

	//private Ray ray;
	//private RaycastHit2D hit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
				
		if ((Utils.ballCount > 0) || (isBallPressed)) 
		{
			Vector2 vec = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (!isBallPressed) {

				if (Input.GetMouseButtonDown (0)) 

					if (Basket.checkCollisionBasket())
					{
						createBall(vec.x, vec.y);	
						BallClickListener.setNewPoints(vec.x, vec.y);
					}

			} else {

				BallClickListener.setNewPoints(vec.x, vec.y);

				if (!Input.GetMouseButtonUp (0)) 
				{
					if (Basket.checkCollisionBasket())
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

		else if (pressedBall.ToString ().Equals("null"))
			Application.LoadLevel (ScorePreferences.levelCompleteName);

	}

	private void createBall(float x, float y)
	{
		pressedBall = Instantiate (ball, new Vector2 (x, y), Quaternion.identity) as GameObject;

		pressedBall.GetComponent<Collider2D>().enabled = false;		
		pressedBall.GetComponent<Rigidbody2D>().isKinematic = true;
		
		Utils.ballCount--;
		
		isBallPressed = true;
	}

	private void moveBallToPressedPosition(Vector2 vec)
	{
		float step = BallPreferences.ballMoveSpeed * Time.deltaTime;

		pressedBall.transform.position = Vector2.MoveTowards (pressedBall.transform.position, vec, step);
	}

	private void releaseBall()
	{
		pressedBall.GetComponent<Collider2D>().enabled = true;
		pressedBall.GetComponent<Rigidbody2D>().isKinematic = false;
		//pressedBall.transform.Rotate (0, 0, BallClickListener.getAngle ());
		pressedBall.GetComponent<Rigidbody2D>().AddForce (new Vector3 (BallClickListener.getPowerX (), BallClickListener.getPowerY (), 0));
		
		isBallPressed = false;
	}

}

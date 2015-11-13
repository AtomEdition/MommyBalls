using UnityEngine;
using System.Collections;

public class FollowMenuCameraController : MonoBehaviour {
	
	public GameObject ball;
	private const float SPAWN_BALL_REPEAT_INTERVAL = 1F;
	private const float SPAWN_BALL_HEIGTH = 5.5F;
	private const float SPAWN_BALL_WIDTH = 2F;
	
	// Update is called once per frame
	void Start () {
		
		InvokeRepeating ("SpawnBall", 0, SPAWN_BALL_REPEAT_INTERVAL);
	}
	
	private void SpawnBall() {

		GameObject newBall = Instantiate (ball, new Vector2 (-SPAWN_BALL_WIDTH, SPAWN_BALL_HEIGTH), Quaternion.identity) as GameObject;
		newBall.gameObject.GetComponent<BallAppearance> ().AttachAnimation ();
		
	}
}

using UnityEngine;
using System.Collections;

public class MainMenuCameraController : MonoBehaviour {

	public GameObject ball;
	private const float SPAWN_BALL_REPEAT_INTERVAL = 0.3F;
	private const float SPAWN_BALL_HEIGHT = 5.5F;
	private const float SPAWN_BALL_WIDTH = 2.5F;

	// Update is called once per frame
	void Start () {

		StartSpawn ();
	}

	private void StartSpawn(){
		
		InvokeRepeating ("SpawnBall", 0, SPAWN_BALL_REPEAT_INTERVAL);
	}

	void SpawnBall() {
		
		float index = Random.Range(-SPAWN_BALL_WIDTH, SPAWN_BALL_WIDTH);
		GameObject newBall = Instantiate (ball, new Vector2 (index, SPAWN_BALL_HEIGHT), Quaternion.identity) as GameObject;
		newBall.gameObject.GetComponent<BallAppearance> ().AttachAnimation ();
	}
}

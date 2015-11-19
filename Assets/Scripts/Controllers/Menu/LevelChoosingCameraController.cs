using UnityEngine;
using System.Collections;

public class LevelChoosingCameraController : MonoBehaviour {

	private InputService inputService = Singleton<InputService>.GetInstance();
	private const float CAMERA_MOVING_POWER = 10F;
	private const float BALL_POWER = 300F;
	private const float SPAWN_BALL_HEIGTH = 3F;
	private const float SPAWN_BALL_OFFSET = 1F;
	private const float SPAWN_BALL_REPEAT_INTERVAL = 0.3F;
	
	public GameObject ball;
	public GameObject buttonUp;
	public GameObject buttonDown;
	public GameObject buttonBack;

	private ProgressService progressService = Singleton<ProgressService>.GetInstance();

	// Use this for initialization
	void Start () {
		
		progressService.LoadArrayFromString ();
		InvokeRepeating ("SpawnBall", 0, SPAWN_BALL_REPEAT_INTERVAL);
	}
	
	// Update is called once per frame
	void Update () {

		//currentSpawnBallHeigth = 
		moveCamera ();
	}
	
	private void SpawnBall() {
		
		float index = Random.Range(-SPAWN_BALL_HEIGTH, SPAWN_BALL_HEIGTH + SPAWN_BALL_OFFSET) + gameObject.transform.position.y;
		int sign = Random.value < .5 ? 1 : -1;
		GameObject newBall = Instantiate (ball, new Vector2 (3 * sign, index), Quaternion.identity) as GameObject;
		newBall.gameObject.GetComponent<BallAppearance> ().AttachAnimation ();
		newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300F * sign, 300F));
		newBall.GetComponent<CircleCollider2D> ().enabled = false;
	}

	private void moveCamera() {

		if (inputService.IsInputHold ()) {

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider == null) {
				return;
			}

			if (hit.collider.gameObject.Equals (buttonUp)) { 

				this.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, CAMERA_MOVING_POWER));
			
			} else if (hit.collider.gameObject.Equals (buttonDown)) {
				
				this.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -CAMERA_MOVING_POWER));
			}

			GetComponentInChildren<ControlPanelLightAppearance> ().SetCondition (true);

		} else {
			
			GetComponentInChildren<ControlPanelLightAppearance> ().SetCondition (false);
		}
	}
}

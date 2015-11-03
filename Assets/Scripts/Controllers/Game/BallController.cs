using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private const float OUT_OF_LEVEL_RANGE = -8F;	
	private const float LEVEL_ENDED_DELAY = 0.5F;

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	private bool isSafeColliding = false;

	// Use this for initialization
	private void Start () {

	}

	// Update is called once per frame
	private void Update () {

		CheckDestroyCondition ();
	}

	private void CheckDestroyCondition(){	

		if (transform.position.y < OUT_OF_LEVEL_RANGE) {

			gameObject.GetComponent<BallController>().DestroyBall();
		}
	}	

	public void DestroyBall() {
		
		levelService.OnBallDestroy.Call ();
		Destroy (gameObject);
	}

	public void OnDestroy() {

		levelService.OnAfterBallDestroy.Call ();
	}

	public bool IsSafeColliding {

		get {
			return isSafeColliding;
		}
		set {
			isSafeColliding = value;
		}
	}
}
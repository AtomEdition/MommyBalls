using UnityEngine;
using System.Collections;

public class MommyController : MonoBehaviour {

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	private const float BALL_DESTROY_DELAY = 0.05F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator OnTriggerEnter2D(Collider2D trigger){

		if (trigger.gameObject.tag == Tags.BALL) {

			levelService.ScoreCurrent++;		
			levelService.OnBallCatch.Call ();

			trigger.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			yield return new WaitForSeconds(BALL_DESTROY_DELAY);

			if (trigger.gameObject != null) {
				Destroy (trigger.gameObject);
			}
		}
	}
}

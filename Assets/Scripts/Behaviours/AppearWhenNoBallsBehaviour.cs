using UnityEngine;
using System.Collections;

public class AppearWhenNoBallsBehaviour : MonoBehaviour {

	private readonly LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {

		levelService.OnBallCreate.eventAttachTo += OnBallsOut;
	}

	private void OnBallsOut() {

		if (levelService.BallCount <= 0) {

			if (gameObject.GetComponent<Renderer>() != null) {
				
				gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
			}	
			if (gameObject.GetComponent<BoxCollider2D>() != null) {
				
				gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;
			}
			if (gameObject.GetComponent<CircleCollider2D>() != null) {
				
				gameObject.GetComponent<CircleCollider2D>().enabled = !gameObject.GetComponent<CircleCollider2D>().enabled;
			}
			if (gameObject.GetComponent<TransferBehaviour>() != null) {
				
				gameObject.GetComponent<TransferBehaviour>().enabled = !gameObject.GetComponent<TransferBehaviour>().enabled;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Level26TutorialController : MonoBehaviour {

	readonly LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {

		levelService.OnBallStick.eventAttachTo += MakeItVisible;
	}

	private void MakeItVisible() {

		GetComponent<TutorialHandController> ().enabled = true;
		GetComponent<SpriteRenderer> ().enabled = true;
		levelService.OnBallStick.eventAttachTo -= MakeItVisible;
	}
}

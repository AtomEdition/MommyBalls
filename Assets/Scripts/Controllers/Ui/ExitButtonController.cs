using UnityEngine;
using System.Collections;

public class ExitButtonController : MonoBehaviour {

	InputService inputService = Singleton<InputService>.GetInstance();
	LevelService levelService = Singleton<LevelService>.GetInstance();
	AdService adService = Singleton<AdService>.GetInstance();

	void Update () {

		OnClick ();
	}

	private void OnClick(){
		
		if (inputService.IsInputDown ()) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
 			if (hit.collider != null && gameObject.Equals (hit.collider.gameObject)) {

				adService.ShowAd();
				Application.LoadLevel(Scenes.LEVEL_CHOOSING);
				levelService.PrepareForNewLevel();
			}

		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour {

	readonly InputService inputService = Singleton<InputService>.GetInstance();
	readonly LevelService levelService = Singleton<LevelService>.GetInstance();
	readonly AdService adService = Singleton<AdService>.GetInstance();

	void Update () {

		OnClick ();
	}

	private void OnClick() {
		
		if (inputService.IsInputDown ()) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
 			if (hit.collider != null && gameObject.Equals (hit.collider.gameObject)) {

				adService.ShowAd();
				SceneManager.LoadScene (Scenes.LEVEL_CHOOSING);
				levelService.PrepareForNewLevel();
			}

		}
	}
}

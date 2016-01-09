using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour {

	public int sceneIndex;
	private readonly InputService inputService = Singleton<InputService>.GetInstance();
	private readonly AdService adService = Singleton<AdService>.GetInstance();

	// Update is called once per frame
	void Update () {
		
		ToSceneListener ();
	}

	private void ToSceneListener() {
		
		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (hit.collider != null
			    && hit.collider.gameObject == gameObject) {

				adService.HideAdmobSmallBanner ();
				SceneManager.LoadScene (sceneIndex);
			}
		}
	}
}

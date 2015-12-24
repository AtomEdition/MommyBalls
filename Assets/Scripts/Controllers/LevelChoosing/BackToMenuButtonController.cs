using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMenuButtonController : MonoBehaviour {

	readonly InputService inputService = Singleton<InputService>.GetInstance();

	void Update() {

		ToMenuListener ();
	}

	private void ToMenuListener() {

		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null
				&& hit.collider.gameObject == this.gameObject) {
		
				SceneManager.LoadScene (Scenes.LEVEL_CHOOSING);
			}
		}
	}
}

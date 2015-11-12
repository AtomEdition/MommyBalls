using UnityEngine;
using System.Collections;

public class MainMenuButtonController : MonoBehaviour {

	public int sceneIndex;
	private InputService inputService = Singleton<InputService>.GetInstance();

	// Update is called once per frame
	void Update () {
		
		ToSceneListener ();
	}

	private void ToSceneListener() {
		
		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (hit.collider != null
			    && hit.collider.gameObject == gameObject) {
				
				Application.LoadLevel(sceneIndex);
			}
		}
	}
}

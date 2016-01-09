using UnityEngine;
using System.Collections;

public class GameExitButtonController : MonoBehaviour {

	private readonly InputService inputService = Singleton<InputService>.GetInstance();

	// Update is called once per frame
	void Update () {

		ExitListener ();	
	}

	private void ExitListener() {

		if (inputService.IsInputDown()) {

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider != null
				&& hit.collider.gameObject == gameObject) {

				Application.Quit ();
			}
		}
	}
}

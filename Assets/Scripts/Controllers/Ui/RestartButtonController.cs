using UnityEngine;
using System.Collections;

public class RestartButtonController : MonoBehaviour {
	
	private LayerMask layerMask = 1 << 5;

	InputService inputService = Singleton<InputService>.GetInstance();
	LevelService levelService = Singleton<LevelService>.GetInstance();
	
	// Update is called once per frame
	void Update () {
		
		OnClick ();
	}	
	
	private void OnClick(){

		if (inputService.IsInputDown () ) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
			if (hit.collider != null && gameObject.Equals (hit.collider.gameObject)) {
				
				Application.LoadLevel(Application.loadedLevel);
				levelService.PrepareForNewLevel();
			}			
		}
	}
}

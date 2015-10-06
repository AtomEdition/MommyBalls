using UnityEngine;
using System.Collections;

public class LevelChoosingButtonController : MonoBehaviour {

	public int levelNumber;

	InputService inputService = Singleton<InputService>.GetInstance();
	
	void Start() {
		
	}
	
	void Update() {
		
		ToLevelListener ();
	}
	
	private void ToLevelListener() {
		
		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (hit.collider != null
			    && hit.collider.gameObject == this.gameObject) {
				
				Application.LoadLevel(Scenes.LEVEL_PREFIX + levelNumber);
			}
		}
	}
}


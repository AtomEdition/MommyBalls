using UnityEngine;
using System.Collections;

public class NextLevelButtonController : MonoBehaviour {
	
	InputService inputService = Singleton<InputService>.GetInstance();
	LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		OnClick ();
	}

	private void OnClick(){
		
		if (inputService.IsInputDown () ) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
			if (hit.collider != null && gameObject.Equals (hit.collider.gameObject)) {
				
				Application.LoadLevel(Application.loadedLevel + 1);
				levelService.PrepareForNewLevel();
			}			
		}
	}
}

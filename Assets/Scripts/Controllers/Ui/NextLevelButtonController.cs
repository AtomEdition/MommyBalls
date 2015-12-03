using UnityEngine;
using System.Collections;

public class NextLevelButtonController : MonoBehaviour {
	
	readonly InputService inputService = Singleton<InputService>.GetInstance();
	readonly LevelService levelService = Singleton<LevelService>.GetInstance();
	readonly ProgressService progressService = Singleton<ProgressService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		SetButtonCondition ();
	}
	
	// Update is called once per frame
	void Update () {
		
		OnClick ();
	}

	private void SetButtonCondition() {

		if (progressService.StarsCountTotal < progressService.LevelsStarsToUnlock [levelService.CurrentLevel]) {

			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<NextLevelButtonAppearance>().SetCondition (false);
		} else {
			
			GetComponent<CircleCollider2D>().enabled = true;
			GetComponent<NextLevelButtonAppearance>().SetCondition (true);
		}
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

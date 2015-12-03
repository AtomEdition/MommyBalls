using UnityEngine;
using System.Collections;

public class ResumeButtonController : MonoBehaviour {
	
	readonly InputService inputService = Singleton<InputService>.GetInstance();
	readonly LevelService levelService = Singleton<LevelService>.GetInstance();
	private GameObject pauseButtonAppearTo;
	public GameObject menuToDestroy;

	// Update is called once per frame
	void Update () {
		
		OnClick ();
	}
	
	private void OnClick(){
		
		if (inputService.IsInputDown ()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);			
			
			if (hit.collider != null && gameObject.Equals (hit.collider.gameObject)) {
				
				pauseButtonAppearTo.GetComponent<SpriteRenderer>().enabled = true;				
				pauseButtonAppearTo.GetComponent<CircleCollider2D>().enabled = true;
				Destroy (menuToDestroy);
				levelService.IsLevelPaused = false;
			}			
		}
	}

	public GameObject PauseButtonAppearTo {
		get {
			return this.pauseButtonAppearTo;
		}
		set {
			pauseButtonAppearTo = value;
		}
	}
}

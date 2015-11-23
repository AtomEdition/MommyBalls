using UnityEngine;
using System.Collections;

public class LevelChoosingButtonController : MonoBehaviour {

	public int levelNumber;
	public int starsToUnlock;

	public Sprite spriteLocked;
	public Sprite spriteEmpty;
	public Sprite spriteBronze;
	public Sprite spriteSilver;
	public Sprite spriteGold;

	InputService inputService = Singleton<InputService>.GetInstance();
	ProgressService progressService = Singleton<ProgressService>.GetInstance();
	
	void Start() {

		SetButtonText ();
		SetButtonImage ();
		SetLockedButtons ();
		starsToUnlock = ProgressProperties.STARS_TO_UNLOCK [levelNumber - 1];
		progressService.LevelsStarsToUnlock [levelNumber - 1] = starsToUnlock;
	}
	
	void Update() {
		
		ToLevelListener ();
	}
	
	private void ToLevelListener() {
		
		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (hit.collider != null
			    && hit.collider.gameObject == gameObject) {
				
				Application.LoadLevel(Scenes.LEVEL_PREFIX + levelNumber);
			}
		}
	}

	private void SetButtonText() {

		TextMesh text = GetComponentInChildren<TextMesh> ();
		text.text = levelNumber.ToString();
	}

	private void SetButtonImage() {

		switch (progressService.GetScoreForLevel (levelNumber)) {
		case 0:
			GetComponent<SpriteRenderer>().sprite = spriteEmpty;
			break;
		case 1:
			GetComponent<SpriteRenderer>().sprite = spriteBronze;
			break;
		case 2:
			GetComponent<SpriteRenderer>().sprite = spriteSilver;
			break;
		case 3:
			GetComponent<SpriteRenderer>().sprite = spriteGold;
			break;
		default:
			GetComponent<SpriteRenderer>().sprite = spriteLocked;
			break;
		}
	}

	private void SetLockedButtons() {

		if (starsToUnlock > progressService.StarsCountTotal) {	

			GetComponent<SpriteRenderer>().sprite = spriteLocked;
			GetComponent<CircleCollider2D>().enabled = false;
			GetComponentInChildren<TextMesh> ().text = "";
		}
	}
}


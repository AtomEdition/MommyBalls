using UnityEngine;
using System.Collections;

public class StarCreateListener : MonoBehaviour {

	public Sprite spriteEmpty;
	public Sprite spriteFull;
	public int starIndex = 1;

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<SpriteRenderer> ().sprite = spriteEmpty;
		CheckStarsCondition();
	}

	private void CheckStarsCondition(){

		if (levelService.GetStarCount() >= starIndex) {

			gameObject.GetComponent<SpriteRenderer> ().sprite = spriteFull;
		}
	}
}

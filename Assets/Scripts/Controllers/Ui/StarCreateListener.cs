using UnityEngine;
using System.Collections;

public class StarCreateListener : MonoBehaviour {

	private const string PREFIX_STAR = "star-";
	private const string PATH_SPRITE_STAR_FULL = "Sprites/Menu/Score/StarFull";

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {

		CheckStarsCondition ();
		levelService.PrepareForNewLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CheckStarsCondition(){

		GameObject star;

		if (levelService.GetStarCount() > 0) {

			for (int i = 0; i < levelService.GetStarCount(); i++) {				
		
				Sprite starFullSprite = Resources.Load<Sprite> (PATH_SPRITE_STAR_FULL);

				star = GameObject.Find (PREFIX_STAR + i);
				star.GetComponent<SpriteRenderer> ().sprite = starFullSprite;
			}
		}
	}
}

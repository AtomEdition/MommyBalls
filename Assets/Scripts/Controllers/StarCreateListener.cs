using UnityEngine;
using System.Collections;

public class StarCreateListener : MonoBehaviour {

	private const string PREFIX_STAR = "star-";
	private const string PATH_SPRITE_STAR_FULL = "Sprites/Menu/Score/StarFull";

	private ScoreService scoreService = Singleton<ScoreService>.GetInstance();
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {

		CheckStarsCondition ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CheckStarsCondition(){

		GameObject star;

		if (GetStarCount () > 0) {

			for (int i = 0; i < GetStarCount (); i++) {				
		
				Sprite starFullSprite = Resources.Load<Sprite> (PATH_SPRITE_STAR_FULL);

				star = GameObject.Find (PREFIX_STAR + i);
				star.GetComponent<SpriteRenderer> ().sprite = starFullSprite;
			}
		}
	}

	private int GetStarCount(){

		return (scoreService.Score < levelService.ScoreStars3)
				? (scoreService.Score < levelService.ScoreStars2)
				? (scoreService.Score < levelService.ScoreStars1)
				? 0
				: 1
				: 2
				: 3;
	}
}

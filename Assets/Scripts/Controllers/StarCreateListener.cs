using UnityEngine;
using System.Collections;

public class StarCreateListener : MonoBehaviour {

	private const string PREFIX_STAR = "star-";
	private const string PATH_SPRITE_STAR_FULL = "Sprites/Ui/Score/StarFull";

	private ScoreService scoreService = Singleton<ScoreService>.getInstance();
	private LevelService levelService = Singleton<LevelService>.getInstance();

	// Use this for initialization
	void Start () {
		checkStarsCondition ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void checkStarsCondition(){

		GameObject star;

		if (getStarCount () > 0)
			for (int i = 0; i < getStarCount (); i++) 
			{				
				Sprite starFullSprite = Resources.Load<Sprite>(PATH_SPRITE_STAR_FULL);

				star = GameObject.Find (PREFIX_STAR + i);
				star.GetComponent<SpriteRenderer>().sprite = starFullSprite;
			}
	}

	private int getStarCount(){

		return (scoreService.Score < levelService.ScoreStars3)
				? (scoreService.Score < levelService.ScoreStars2)
				? (scoreService.Score < levelService.ScoreStars1)
				? 0
				: 1
				: 2
				: 3;
	}
}

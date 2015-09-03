using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	private const string starPrefix = "star-";
	private const string pathSpriteStarFull = "Sprites/Ui/Score/StarFull";

	// Use this for initialization
	void Start () {
		checkStarsCondition ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void checkStarsCondition()
	{
		GameObject star;

		if (getStarCount () > 0)
			for (int i = 0; i < getStarCount (); i++) 
			{				
				Sprite starFullSprite = Resources.Load<Sprite>(pathSpriteStarFull);

				star = GameObject.Find (starPrefix + i);
				star.GetComponent<SpriteRenderer>().sprite = starFullSprite;
			}
	}

	private int getStarCount()
	{
		if (Utils.score >= Utils.scoreStars3)
			return 3;

		else if (Utils.score >= Utils.scoreStars2)
			return 2;

		else if (Utils.score >= Utils.scoreStars1)
			return 1;

		return 0;
	}
}

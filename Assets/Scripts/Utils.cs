using UnityEngine;
using System.Collections;

public class Utils {
	
	public static int score = 0;
	public static int ballCount = 5;
	public const int scoreStars3 = 5;	
	public const int scoreStars2 = 3;
	public const int scoreStars1 = 1;

	public static string getTextBallCount(){

		return GameUiPreferences.textBallCount + ballCount;
	}

	public static string getTextScore(){
		
		return GameUiPreferences.textScore + score;
	}
}

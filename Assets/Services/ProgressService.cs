using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class ProgressService {

	private const int LEVEL_COUNT = 35;
	private const char DELIMITER = '-';
	private const string PREFS_PROGRESS_KEY = "progress";

	private int[] progress = new int[LEVEL_COUNT];

	public ProgressService ()
	{
	}
	
	public void UpdateScore(int currentLevel, int starsCount) {
		int oldScore = Progress [currentLevel - 1];
		Progress [currentLevel - 1] = starsCount > oldScore 
			? starsCount : oldScore;
		PlayerPrefs.SetString (PREFS_PROGRESS_KEY, EncodeArrayInString ());
		PlayerPrefs.Save ();
	}

	public int GetScoreForLevel(int level) {
		return Progress [level - 1];
	}

	private string EncodeArrayInString(){
		StringBuilder sb = new StringBuilder ();
		foreach (int number in Progress) {
			sb.Append(number).Append(DELIMITER);
		}
		return sb.ToString ();
	}

	public void LoadArrayFromString() {
		char[] charsToTrim = {' ', '-'};
		string input = PlayerPrefs.GetString (PREFS_PROGRESS_KEY).Trim(charsToTrim);
		string[] splittedString = input.Split (DELIMITER);
		progress = Array.ConvertAll<string, int> (splittedString, int.Parse);
	}

	public int[] Progress {
		get {
			return this.progress;
		}
	}
}

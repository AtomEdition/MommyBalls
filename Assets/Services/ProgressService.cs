using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class ProgressService {

	private const int LEVEL_COUNT = 36;
	private const char DELIMITER = '-';
	private const string PREFS_PROGRESS_KEY = "progress";

	private int starsCountTotal = 0;

	private int[] progress = new int[LEVEL_COUNT];
	private int[] levelsStarsToUnlock = new int[LEVEL_COUNT];

	public void UpdateScore(int currentLevel, int starsCount) {
		int oldScore = Progress [currentLevel - 1];
		Progress [currentLevel - 1] = starsCount > oldScore 
			? starsCount : oldScore;
		PlayerPrefs.SetString (PREFS_PROGRESS_KEY, EncodeArrayInString ());
		PlayerPrefs.Save ();
	}

	public int GetProgressForLevel(int level) {
		return Progress [level - 1];
	}
	
	public int GetStarsNeededForLevel(int level) {
		return ProgressProperties.STARS_TO_UNLOCK [level - 1];
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

		string input = "2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2-2";//PlayerPrefs.GetString (PREFS_PROGRESS_KEY).Trim(charsToTrim);
		CheckSavesOnCorrectBounds (input);
	}

	private void CheckSavesOnCorrectBounds(string input) {
		string[] splittedString = input.Split (DELIMITER);
		if (splittedString.Length < LEVEL_COUNT) {
			input += "-0";
			CheckSavesOnCorrectBounds (input);
		} else {
			progress = Array.ConvertAll<string, int> (splittedString, int.Parse);
			SetStarsCountTotal ();
		}
	}

	public void SetStarsCountTotal(){

		starsCountTotal = 0;
		foreach (int number in progress) {
			starsCountTotal += number;
		}
	}	
	
	public int GetLastUnlockedLevel() {

		for (int i = 0; i < ProgressProperties.STARS_TO_UNLOCK.Length; i++) {

			if (starsCountTotal < ProgressProperties.STARS_TO_UNLOCK[i]) { return i; }
		}

		return 0;
	}

	public int[] Progress {
		get {
			return this.progress;
		}
	}

	public int StarsCountTotal {
		get {
			return this.starsCountTotal;
		}
	}

	public int[] LevelsStarsToUnlock {
		get {
			return this.levelsStarsToUnlock;
		}
		set {
			levelsStarsToUnlock = value;
		}
	}
}

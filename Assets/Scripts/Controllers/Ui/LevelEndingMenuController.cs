using UnityEngine;
using System.Collections;

public class LevelEndingMenuController : MonoBehaviour {
	
	readonly LevelService levelService = Singleton<LevelService>.GetInstance();
	readonly ProgressService progressService = Singleton<ProgressService>.GetInstance();
	public GameObject menuPrefab;

	// Use this for initialization
	void Start () {

		levelService.OnAfterBallDestroy.eventAttachTo += CheckForLevelEnded;
		menuPrefab.GetComponent<Renderer>().sortingLayerName = "Ui";	
	}
		
	public void CheckForLevelEnded() {		
		
		if (levelService.BallCount <= 0 
		    && GameObject.FindGameObjectsWithTag(Tags.BALL).Length == 0) {
			
			Instantiate(menuPrefab, new Vector2 (), Quaternion.identity);
			levelService.IsLevelPaused = true;
			progressService.UpdateScore(levelService.CurrentLevel, levelService.GetStarCount());
			progressService.SetStarsCountTotal ();
		}
	}
}

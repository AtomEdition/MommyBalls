using UnityEngine;
using System.Collections;

public class LevelEndingMenuController : MonoBehaviour {
	
	LevelService levelService = Singleton<LevelService>.GetInstance();
	public GameObject menuPrefab;

	// Use this for initialization
	void Start () {

		levelService.OnAfterBallDestroy.eventAttachTo += CheckForLevelEnded;
		menuPrefab.GetComponent<Renderer>().sortingLayerName = "Ui";	
	}
		
	public void CheckForLevelEnded() {		
		
		if (levelService.BallCount <= 0 
		    && GameObject.FindGameObjectsWithTag(Tags.BALL).Length == 0) {
			
			GameObject menu = Instantiate(menuPrefab, new Vector2 (), Quaternion.identity) as GameObject;
			levelService.IsLevelPaused = true;
		}
	}
}

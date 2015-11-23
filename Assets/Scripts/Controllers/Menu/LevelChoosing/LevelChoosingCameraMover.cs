using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelChoosingCameraMover : MonoBehaviour {

	private ProgressService progressService = Singleton<ProgressService>.GetInstance();
	private Dictionary<int, float> levelsUnlocks = new Dictionary<int, float>();
	
	void Start () {

		LoadLevelUnlocks ();
		SetCameraPosition ();
	}

	private void SetCameraPosition() {

		Vector3 vec = gameObject.transform.position;
		vec.y = GetCameraY (progressService.GetLastUnlockedLevel());
		gameObject.transform.position = vec;
	}

	private void LoadLevelUnlocks() {
		
		levelsUnlocks.Add (1, 0.05F);
		levelsUnlocks.Add (10, 3.45F);
		levelsUnlocks.Add (16, 12.24F);
		levelsUnlocks.Add (20, 16.65F);
		levelsUnlocks.Add (26, 24.0F);
		levelsUnlocks.Add (31, 27.15F);
	}
	
	public float GetCameraY(int lastUnlockedLevel) {
		
		float value = 0;
		for (int i = 0; i <= lastUnlockedLevel; i++) {
			
			if (levelsUnlocks.ContainsKey (i)) {
				levelsUnlocks.TryGetValue (i, out value);
			}
		}
		return value;
	}
}

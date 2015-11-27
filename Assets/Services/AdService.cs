using UnityEngine;
using UnityEngine.Advertisements;

public class AdService : MonoBehaviour {

	public void ShowAd()
	{
		try {
			if (Advertisement.IsReady()) {

				Advertisement.Show();
			}
		} catch (UnityException e) {

			Debug.LogWarning(e.Message);
		}
	}

	public bool IsShowingNow() {

		return Advertisement.isShowing;
	}
}

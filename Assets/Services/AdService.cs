using UnityEngine;
using UnityEngine.Advertisements;

public class AdService : MonoBehaviour {

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	public bool IsShowingNow() {

		return Advertisement.isShowing;
	}
}

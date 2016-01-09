using UnityEngine;
using GoogleMobileAds.Api;

public class AdService {

	#if UNITY_ANDROID
	private const string SMALL_MENU_BANNER_ID = "ca-app-pub-9550981282535152/6062764220";
	private const string INTERSTIAL_ID = "ca-app-pub-9550981282535152/7539497424";
	#else
	private const string SMALL_MENU_BANNER_ID = "ca-app-pub-9550981282535152/4746724221";
	private const string INTERSTIAL_ID = "ca-app-pub-9550981282535152/7700190629";
	#endif	

	private BannerView bannerView;
	private InterstitialAd interstialAd;

	public void ShowAdmobSmallBanner() {
		bannerView = new BannerView (SMALL_MENU_BANNER_ID, AdSize.Banner, AdPosition.Top);
		AdRequest request = new AdRequest.Builder ().Build ();
		bannerView.LoadAd (request);
	}

	public void HideAdmobSmallBanner() {

		bannerView.Hide ();
	}

	public void LoadAdmobInterstial() {
		interstialAd = new InterstitialAd (INTERSTIAL_ID);
		AdRequest request = new AdRequest.Builder ().Build ();
		if (!interstialAd.IsLoaded ()) {
			interstialAd.LoadAd (request);
		}
	}

	public void ShowAdmobInterstial() {
		
		if (interstialAd.IsLoaded ()) {
			interstialAd.Show();
		}
	}

	//public void ShowUnityServiceAd()
	//{
	//	try {
	//		if (Advertisement.IsReady()) {
	//
	//			Advertisement.Show();
	//		}
	//	} catch (UnityException e) {
	//
	//		Debug.LogWarning(e.Message);
	//	}
	//}

	//public bool IsUnityAdShowingNow() {

	//	return Advertisement.isShowing;
	//}
}

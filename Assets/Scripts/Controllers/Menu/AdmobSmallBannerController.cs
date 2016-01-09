using UnityEngine;
using System.Collections;

public class AdmobSmallBannerController : MonoBehaviour {

	private AdService adService = Singleton<AdService>.GetInstance ();

	// Use this for initialization
	void Start () {
	
		adService.ShowAdmobSmallBanner ();
	}
}

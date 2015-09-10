using UnityEngine;
using System.Collections;

public class TextBallsUSpdateListener : MonoBehaviour {

	private InterfaceService interfaceService = Singleton<InterfaceService>.getInstance();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Sthis.GetComponent<GUIText>().text = interfaceService.getTextBallCount ();
	}
}

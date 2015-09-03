using UnityEngine;
using System.Collections;

public class TextBalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<GUIText>().text = Utils.getTextBallCount ();
	}
}

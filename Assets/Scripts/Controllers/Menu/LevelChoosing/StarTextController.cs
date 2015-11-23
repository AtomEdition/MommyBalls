using UnityEngine;
using System.Collections;

public class StarTextController : MonoBehaviour {

	ProgressService progressService = Singleton<ProgressService>.GetInstance();
	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Renderer> ().sortingOrder = 12;
		gameObject.GetComponent<TextMesh> ().alignment = TextAlignment.Center;
		gameObject.GetComponent<TextMesh> ().text = progressService.StarsCountTotal.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

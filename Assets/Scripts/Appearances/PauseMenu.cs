using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Renderer>().sortingLayerName = "Ui";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

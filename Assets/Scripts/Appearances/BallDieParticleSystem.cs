using UnityEngine;
using System.Collections;

public class BallDieParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerName = "Foreground";
		GetComponent<Renderer>().sortingOrder = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

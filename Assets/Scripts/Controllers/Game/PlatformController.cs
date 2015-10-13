using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public CustomEvent onBallCollide = new CustomEvent();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {

		onBallCollide.Call ();
	}
}

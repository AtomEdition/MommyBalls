using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public CustomEvent onBallCollide = new CustomEvent();

	void OnCollisionEnter2D () {

		onBallCollide.Call ();
	}
}

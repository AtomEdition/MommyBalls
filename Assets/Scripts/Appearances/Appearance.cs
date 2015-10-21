using UnityEngine;

public class Appearance : MonoBehaviour
{
	void Update() {
		RendererListener ();
	}

	void RendererListener() {
		
		SpriteRenderer[] array = GetComponentsInChildren<SpriteRenderer> ();

		foreach (SpriteRenderer sr in array) {

			sr.enabled = GetComponentInParent<SpriteRenderer>().enabled;
		}
	}
}


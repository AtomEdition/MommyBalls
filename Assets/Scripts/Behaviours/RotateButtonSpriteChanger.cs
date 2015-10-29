using UnityEngine;
using System.Collections;

public class RotateButtonSpriteChanger : MonoBehaviour {

	public Sprite idle;
	public Sprite hold;

	public void SetCondition(bool isHold) {
		if (isHold) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = hold;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = idle;			
		}
	}
}

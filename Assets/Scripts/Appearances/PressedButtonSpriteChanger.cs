using UnityEngine;
using System.Collections;

public class PressedButtonSpriteChanger : MonoBehaviour {

	public Sprite idle;
	public Sprite hold;

	private bool isPressed = false;

	private InputService inputService = Singleton<InputService>.GetInstance();

	public void Update() {		
		
		if (inputService.IsInputHold ()) {			
			
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider != null && hit.collider.gameObject == gameObject) {

				IsPressed = true;
			
			} else {

				IsPressed = false;
			}
		} else {

			IsPressed = false;
		}
	}

	public void SetCondition(bool isHold) {
		if (isHold) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = hold;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = idle;			
		}
	}

	private bool IsPressed {
		get {
			return this.isPressed;
		}
		set {
			if (isPressed != value) { 
				isPressed = value;
				SetCondition (value);
			}
		}
	}
}

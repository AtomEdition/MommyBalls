using UnityEngine;
using System.Collections;

public class PressedButtonSpriteChanger : MonoBehaviour {

	public Sprite idle;
	public Sprite hold;

	private bool isPressed;

	private readonly InputService inputService = Singleton<InputService>.GetInstance();

	public void Update() {		
		
		if (inputService.IsInputHold ()) {			
			
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			IsPressed = hit.collider != null && hit.collider.gameObject == gameObject;

		} else {

			IsPressed = false;
		}
	}

	public void SetCondition(bool isHold) {

		gameObject.GetComponent<SpriteRenderer> ().sprite = isHold ? hold : idle;
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

using UnityEngine;

public class InputService {

	private float timeInputDown;
	private float timeInputUp;

	public bool IsInputDown() {

		if (Input.GetMouseButtonDown (0)) {

			timeInputDown = Time.fixedTime;
			return true;
		}

		return false;
	}

	public bool IsInputUp() {
		
		if (Input.GetMouseButtonUp (0)) {

			timeInputUp = Time.fixedTime;
			return true;
		}
		
		return false;
	}
	
	public bool IsInputHold() {
		
		return Input.GetMouseButton (0);
	}

	public float GetTimeOfClick() {

		return timeInputUp - timeInputDown;
	}
}

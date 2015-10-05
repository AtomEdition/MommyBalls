using UnityEngine;

public class InputService {

	private float timeInputDown;
	private float timeInputUp;

	public bool IsInputDown() {

		if (Input.GetMouseButtonDown (0)
		    || (Input.touchCount > 0 
		    && Input.GetTouch(0).phase == TouchPhase.Began)) {

			timeInputDown = Time.fixedTime;
			return true;
		}

		return false;
	}

	public bool IsInputUp() {
		
		if (Input.GetMouseButtonUp (0)
		    || (Input.touchCount > 0 
		    && (Input.GetTouch(0).phase == TouchPhase.Canceled
		    || Input.GetTouch(0).phase == TouchPhase.Ended))) {

			timeInputUp = Time.fixedTime;
			return true;
		}
		
		return false;
	}
	
	public bool IsInputHold() {
		
		return Input.GetMouseButton (0)
				|| (Input.touchCount > 0 
				&& Input.GetTouch(0).phase == TouchPhase.Stationary);
	}

	public float GetTimeOfClick() {

		return timeInputUp - timeInputDown;
	}
}

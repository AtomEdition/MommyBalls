using UnityEngine;
using System.Collections;

public class MenuButtonRandomPositionAndAngle : MonoBehaviour {
	
	private const float BUTTON_ANGLE = 30F;
	private const float BUTTON_POSITION = 1.5F;

	// Use this for initialization
	void Start () {
		
		SetButtonAngleAndPosition ();
	}
	
	private void SetButtonAngleAndPosition (){
		
		float angle = Random.Range(-BUTTON_ANGLE, BUTTON_ANGLE);
		float position = Random.Range(-BUTTON_POSITION, BUTTON_POSITION);
		gameObject.transform.eulerAngles = new Vector3 (0, 0, angle);
		gameObject.transform.position = new Vector3 (position, transform.position.y, transform.position.z);
	}
}

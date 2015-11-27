using UnityEngine;
using System.Collections;

public class DelayActivatorController : SwitcherBaseClass {

	public float secondsOfDelay;
	public GameObject[] elementsToActivateDelay = {};
		
	IEnumerator OnTriggerEnter2D(Collider2D trigger){
		
		if (trigger.gameObject.tag == Tags.BALL) {

			ChangeCondition ();

			yield return new WaitForSeconds(secondsOfDelay);
			
			ChangeCondition ();
		}
	}

	private void ChangeCondition() {
					
		foreach (GameObject obj in elementsToActivateDelay) {
			
			SwitchAllComponents(obj);
		}

		SwitchAllComponents (gameObject);
	}
}

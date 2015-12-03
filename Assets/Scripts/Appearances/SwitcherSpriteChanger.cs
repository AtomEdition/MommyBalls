using UnityEngine;
using System.Collections;

public class SwitcherSpriteChanger : MonoBehaviour {

	public Color colorEnabled;
	public Color colorDisabled;

	private SwitcherBehaviour swCtrl;

	// Use this for initialization
	void Start () {
	
		swCtrl = gameObject.GetComponent<SwitcherBehaviour> ();
		AttachMethodsToEvent ();
		ChangeSprite ();
	}

	private void AttachMethodsToEvent() {

		swCtrl.onSwitchEvent.eventAttachTo += this.ChangeSprite;
	}
		
	private void ChangeSprite() {

		ChangeLightColor (swCtrl.TurnedOn);
	}	
	
	private void ChangeLightColor(bool isTurnedOn) {
		
		SpriteRenderer[] array = GetComponentsInChildren<SpriteRenderer> ();
		
		foreach (SpriteRenderer sr in array) {
			
			if (Tags.SWITCHER_LIGHT.Equals (sr.gameObject.tag)) {

				sr.color = isTurnedOn ? Color.green : Color.red;
			}
		}
	}
}

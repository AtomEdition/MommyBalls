using UnityEngine;
using System.Collections;

public class SwitcherSpriteChanger : MonoBehaviour {
	
	private const string PATH_SPRITE_SWITCH_ENABLED = "Sprites/Game/Additional/SwitcherOn";
	private const string PATH_SPRITE_SWITCH_DISABLED = "Sprites/Game/Additional/SwitcherOff";

	private SwitcherBehaviour swCtrl;

	// Use this for initialization
	void Start () {
	
		swCtrl = gameObject.GetComponent<SwitcherBehaviour> ();
		AttachMethodsToEvent ();
		ChangeSprite ();
	}
	
	// Update is called once per frame
	void Update () {
	
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

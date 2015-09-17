using UnityEngine;
using System.Collections;

public class SwitcherSpriteChanger : MonoBehaviour {
	
	private const string PATH_SPRITE_SWITCH_ENABLED = "Sprites/Game/Additional/SwitcherOn";
	private const string PATH_SPRITE_SWITCH_DISABLED = "Sprites/Game/Additional/SwitcherOff";

	private SwitcherController swCtrl;

	// Use this for initialization
	void Start () {
	
		swCtrl = gameObject.GetComponent<SwitcherController> ();
		attachMethodsToEvent ();
		changeSprite ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void attachMethodsToEvent() {

		swCtrl.onSwitchEvent += this.changeSprite;
	}
		
	private void changeSprite() {

		changeSprite (swCtrl.TurnedOn);
	}

	private void changeSprite(bool isTurnedOn) {		
		
		Sprite switcherSprite;
		if (isTurnedOn) {
			
			switcherSprite = Resources.Load<Sprite> (PATH_SPRITE_SWITCH_ENABLED);
			
		} else {
			
			switcherSprite = Resources.Load<Sprite> (PATH_SPRITE_SWITCH_DISABLED);
		}
		
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = switcherSprite;
	}
}

using UnityEngine;
using System.Collections;

public class SwitcherBehaviour : SwitcherBaseClass {

	public bool turnedOnFromScene;
	private bool turnedOn;
	private bool isTriggered;

	public GameObject[] switchingElements = {};
	public GameObject[] switchingSwitchers = {};

	public CustomEvent onSwitchEvent = new CustomEvent();

	// Use this for initialization
	void Start () {

		TurnedOn = turnedOnFromScene;
		AttachMethodsToEvent ();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == Tags.BALL) {

			isTriggered = true;
			onSwitchEvent.Call ();
		}
	}
		
	void OnTriggerEnter2D(Collider2D trigger){
		
		if (trigger.gameObject.tag == Tags.BALL) {
			
			isTriggered = true;
			onSwitchEvent.Call ();
		}
	}

	private void AttachMethodsToEvent(){

		onSwitchEvent.eventAttachTo += this.ChangeFlags;
		onSwitchEvent.eventAttachTo += this.SwitchElements;
		onSwitchEvent.eventAttachTo += this.SwitchSwitchers;
	}

	private void ChangeFlags(){

		TurnedOn = !TurnedOn;
	}
		
	private void SwitchElements () {

		foreach (GameObject obj in switchingElements) {

			SwitchAllComponents(obj);
		}
	}

	private void SwitchSwitchers() {
		
		foreach (GameObject obj in switchingSwitchers) {

			SwitcherBehaviour swCtrl = obj.GetComponent<SwitcherBehaviour>();

			if (!swCtrl.isTriggered) {

				swCtrl.onSwitchEvent.Call ();

			} else {

				swCtrl.isTriggered = false;

			}
		}
	}

	public bool TurnedOn {
		get {
			return this.turnedOn;
		}
		set {
			turnedOn = value;
		}
	}
}

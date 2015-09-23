using UnityEngine;
using System.Collections;

public class SwitcherController : MonoBehaviour {

	public bool turnedOnFromScene = false;
	private bool turnedOn;
	private bool isTriggered = false;
	private const string PATH_SPRITE_SWITCH_ENABLED = "Sprites/Game/Additional/SwitcherOn";
	private const string PATH_SPRITE_SWITCH_DISABLED = "Sprites/Game/Additional/SwitcherOff";

	public GameObject[] switchingElements = {};
	public GameObject[] switchingSwitchers = {};

	public delegate void MethodContainer();
	public event MethodContainer onSwitchEvent;

	// Use this for initialization
	void Start () {

		TurnedOn = turnedOnFromScene;
		AttachMethodsToEvent ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball") {

			isTriggered = true;
			onSwitchEvent ();
		}
	}

	private void AttachMethodsToEvent(){

		this.onSwitchEvent += this.ChangeFlags;
		this.onSwitchEvent += this.SwitchElements;
		this.onSwitchEvent += this.SwitchSwitchers;
	}

	private void ChangeFlags(){

		TurnedOn = !TurnedOn;
	}
		
	private void SwitchElements () {

		foreach (GameObject obj in switchingElements) {

			if (obj.GetComponent<Renderer>() != null) {

				obj.GetComponent<Renderer>().enabled = !obj.GetComponent<Renderer>().enabled;
			}
			if (obj.GetComponent<BoxCollider2D>() != null) {

				obj.GetComponent<BoxCollider2D>().enabled = !obj.GetComponent<BoxCollider2D>().enabled;
			}
			if (obj.GetComponent<CircleCollider2D>() != null) {
				
				obj.GetComponent<CircleCollider2D>().enabled = !obj.GetComponent<CircleCollider2D>().enabled;
			}
		}
	}

	private void SwitchSwitchers() {
		
		foreach (GameObject obj in switchingSwitchers) {

			SwitcherController swCtrl = obj.GetComponent<SwitcherController>();

			if (!swCtrl.isTriggered) {

				swCtrl.onSwitchEvent ();

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

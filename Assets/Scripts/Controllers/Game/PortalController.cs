using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	public GameObject[] bindedPortals = {};
	public GameObject ball;

	private bool isActive = true;
	private static bool isTeleportatingNow = false;

	public delegate void MethodContainer(bool flag);
	public event MethodContainer onSwitchPortalCondition;

	public CustomEvent onTeleportate = new CustomEvent();

	// Use this for initialization
	void Start () {

		onSwitchPortalCondition += SetPortalCondition;	
	}

	void OnTriggerEnter2D(Collider2D trigger){

		if (trigger.gameObject.tag == Tags.BALL) {

			if (!isTeleportatingNow) {
		
				onSwitchPortalCondition (false);
				onTeleportate.Call();
		
				TurnOnExitsFromPortal (this);

				foreach (GameObject bindedPortal in bindedPortals) {

					float angle = bindedPortal.transform.eulerAngles.z - this.gameObject.transform.eulerAngles.z + 180;

					Vector2 newPosition = bindedPortal.transform.position;
					
					Vector2 speed = trigger.gameObject.GetComponent<Rigidbody2D> ().velocity;
					speed = GetNewVectorForObject (angle, speed);

					GameObject createdBall = Instantiate (trigger.gameObject, newPosition, Quaternion.identity) as GameObject;
					
					createdBall.GetComponent<CircleCollider2D>().enabled = true;
					createdBall.GetComponent<BallController>().enabled = true;
					createdBall.GetComponent<BallAppearance>().enabled = true;		
					createdBall.GetComponentInChildren<Animator>().enabled = true;	
					createdBall.GetComponent<BallAppearance>().SetFlyingAnimation ();
					createdBall.GetComponent<Rigidbody2D> ().isKinematic = false;

					createdBall.GetComponent<Rigidbody2D> ().velocity = speed;
					Destroy (trigger.gameObject);
				} 
			}
		}
	}

	private Vector2 GetNewVectorForObject(float angle, Vector2 newPosition) {

		float angleInRads = Mathf.Deg2Rad * angle;
		float x = newPosition.x * Mathf.Cos (angleInRads) - newPosition.y * Mathf.Sin (angleInRads);
		float y = newPosition.x * Mathf.Sin (angleInRads) + newPosition.y * Mathf.Cos (angleInRads);

		return new Vector2 (x, y);
	}

	void OnTriggerExit2D(Collider2D trigger){

		onSwitchPortalCondition (true);
	}

	private void SetPortalCondition(bool isEnabled) {

		this.IsActive = isEnabled;
		isTeleportatingNow = !isEnabled;
	}

	private void TurnOnExitsFromPortal(PortalController portalController){

		foreach (GameObject portal in portalController.bindedPortals) {

			portal.GetComponent<PortalController>().IsActive = true;
		}			
	}

	bool IsActive {
		get {
			return this.isActive;
		}
		set {
			isActive = value;
		}
	}
}

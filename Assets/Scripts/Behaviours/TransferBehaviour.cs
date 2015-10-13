using UnityEngine;
using System.Collections;

public class TransferBehaviour : MonoBehaviour {
	
	private const float TRANSFER_SPEED = 0.03F;

	public float speedMultiplierX;
	public float speedMultiplierY;

	private int direction;
	private float speed;
	private bool isTriggered = false;

	// Use this for initialization
	void Start () {

		Speed = TRANSFER_SPEED;
	}

	// Update is called once per frame
	void Update () {

		this.gameObject.transform.Translate 
			(new Vector2 (Speed * speedMultiplierX, Speed * speedMultiplierY));
	}

	void OnTriggerEnter2D(Collider2D trigger){

		if (!Tags.BALL.Equals(trigger.gameObject.tag)
		    && !isTriggered) {

			Speed *= -1;
			isTriggered = true;

		} 
	}

	void OnTriggerExit2D(Collider2D trigger){

		isTriggered = false;
	}

	private float Speed {
		get {
			return this.speed;
		}
		set {
			speed = value;
		}
	}
}

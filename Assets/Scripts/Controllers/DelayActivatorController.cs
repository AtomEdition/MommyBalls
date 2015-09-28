using UnityEngine;
using System.Collections;

public class DelayActivatorController : MonoBehaviour {

	public float secondsOfDelay;
	public GameObject[] elementsToActivateDelay = {};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	IEnumerator OnTriggerEnter2D(Collider2D trigger){
		
		if (trigger.gameObject.tag == Tags.BALL) {

			ChangeCondition ();

			yield return new WaitForSeconds(secondsOfDelay);
			
			ChangeCondition ();
		}
	}

	private void ChangeCondition() {
					
		foreach (GameObject obj in elementsToActivateDelay) {
			
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

		this.gameObject.GetComponent<Renderer>().enabled = !this.gameObject.GetComponent<Renderer>().enabled;
		this.gameObject.GetComponent<Collider2D>().enabled = !this.gameObject.GetComponent<Collider2D>().enabled;
	}
}

using UnityEngine;
using System.Collections;

public class Mommy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Ball") {

			yield return new WaitForSeconds(0.05F);
			Destroy (collision.gameObject);

			Utils.score++;			
		}
	}
}

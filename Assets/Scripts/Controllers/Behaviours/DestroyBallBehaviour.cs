using UnityEngine;
using System.Collections;

public class DestroyBallBehaviour : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == Tags.BALL
		    && !collision.gameObject.GetComponent<BallController>().IsSafeColliding) {

			Destroy (collision.gameObject);					
		}
	}
}

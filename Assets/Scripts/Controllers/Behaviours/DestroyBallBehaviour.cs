using UnityEngine;
using System.Collections;

public class DestroyBallBehaviour : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball") {

			collision.gameObject.GetComponent<BallController>().DestroyBall();
					
		}
	}
}

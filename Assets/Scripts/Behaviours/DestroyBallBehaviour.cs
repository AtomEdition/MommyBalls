using UnityEngine;
using System.Collections;

public class DestroyBallBehaviour : MonoBehaviour {

	public CustomEvent onBallCollide = new CustomEvent();
	public ParticleSystem particles = new ParticleSystem();

	private void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == Tags.BALL
		    && !collision.gameObject.GetComponent<BallController>().IsSafeColliding) {

			collision.gameObject.GetComponent<BallController>().DestroyBall();		
			ParticleSystem newParticles = Instantiate (particles, collision.transform.position, Quaternion.identity) as ParticleSystem;
			newParticles.GetComponent<Renderer> ().sortingLayerName = "Foreground";

			onBallCollide.Call();
		}
	}
}

using UnityEngine;
using System.Collections;

public class DestroyBallBehaviour : MonoBehaviour {

	private const float PARTICLES_LIFE_TIME = 0.5F;
	public CustomEvent onBallCollide = new CustomEvent();
	public ParticleSystem particles = new ParticleSystem();

	private IEnumerator OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == Tags.BALL
		    && !collision.gameObject.GetComponent<BallController>().IsSafeColliding) {

			collision.gameObject.GetComponent<BallController>().DestroyBall();		
			GameObject newParticles = Instantiate (particles, collision.transform.position, Quaternion.identity) as GameObject;

			onBallCollide.Call();

			yield return new WaitForSeconds (PARTICLES_LIFE_TIME);
			Destroy (newParticles);
		}
	}
}

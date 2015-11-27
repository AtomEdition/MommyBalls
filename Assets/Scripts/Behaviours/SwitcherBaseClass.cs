using UnityEngine;
using System.Collections;

public class SwitcherBaseClass : MonoBehaviour {

	protected void SwitchAllComponents(GameObject obj) {
		
		SwitchRenderers<SpriteRenderer>(obj);
		SwitchBehaviours<BoxCollider2D>(obj);
		SwitchBehaviours<CircleCollider2D>(obj);
		SwitchParticles(obj);
	}
	
	private void SwitchBehaviours<T>(GameObject obj) where T : Behaviour {
		
		foreach (T t in obj.GetComponentsInChildren<T>()) {
			
			if (t != null) {t.enabled = !t.enabled;}
		}
	}
	
	private void SwitchRenderers<T>(GameObject obj) where T : Renderer {
		
		foreach (T t in obj.GetComponentsInChildren<T>()) {
			
			if (t != null) {t.enabled = !t.enabled;}
		}
	}
	
	private void SwitchParticles(GameObject obj) {
		
		foreach (ParticleSystem t in obj.GetComponentsInChildren<ParticleSystem>()) {
			
			if (t != null && t.isPlaying) {
				t.Stop ();
			} else {
				t.Play ();
			}
		}
	}
}

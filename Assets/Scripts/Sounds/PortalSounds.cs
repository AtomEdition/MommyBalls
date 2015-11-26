using UnityEngine;
using System.Collections;

public class PortalSounds : MonoBehaviour {
	
	private const int PORTAL_SOUNDS_COUNT = 1;
	private const string PORTAL_SOUND_CLIP_PATH = "Sounds/Portal/PortalSound";
	
	private AudioSource onPortalCollideAudioSource; 
		
	// Use this for initialization
	void Start () {
		
		onPortalCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<PortalController> ().onTeleportate.eventAttachTo += makePortalSound;
	}
	
	private void makePortalSound(){
		
		onPortalCollideAudioSource.clip = Resources.Load<AudioClip> (PORTAL_SOUND_CLIP_PATH + Random.Range(0, PORTAL_SOUNDS_COUNT));
		onPortalCollideAudioSource.Play ();
	}
}

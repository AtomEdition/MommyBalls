using UnityEngine;
using System.Collections;

public class StickyPlatformSounds : MonoBehaviour {
			
	private const int JUMPER_SOUNDS_COUNT = 2;
	private const string STICKY_PLATFORM_SOUND_CLIP_PATH = "Sounds/StickyPlatform/stickyPlatformSound";
	
	private AudioSource onStickyPlatformCollideAudioSource; 
	
	// Use this for initialization
	void Start () {
		
		onStickyPlatformCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<StickyPlatformController> ().onBallCollide.eventAttachTo += this.makePlatformSound;
	}
	
	private void makePlatformSound(){
		
		onStickyPlatformCollideAudioSource.clip = Resources.Load<AudioClip> (STICKY_PLATFORM_SOUND_CLIP_PATH + Random.Range (0, JUMPER_SOUNDS_COUNT));
		onStickyPlatformCollideAudioSource.Play ();
	}
}

using UnityEngine;
using System.Collections;

public class PlatformSounds : MonoBehaviour {
	
	private const int PLATFORM_SOUNDS_COUNT = 1;
	private const string PLATFORM_SOUND_CLIP_PATH = "Sounds/Platform/platformSound";

	private AudioSource onPlatformCollideAudioSource; 

	// Use this for initialization
	void Start () {
		
		onPlatformCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<PlatformController> ().onBallCollide.eventAttachTo += makePlatformSound;
	}

	private void makePlatformSound(){
		
		onPlatformCollideAudioSource.clip = Resources.Load<AudioClip> (PLATFORM_SOUND_CLIP_PATH + Random.Range(0, PLATFORM_SOUNDS_COUNT));
		onPlatformCollideAudioSource.Play ();
	}
}

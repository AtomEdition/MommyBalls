using UnityEngine;
using System.Collections;

public class StickyPlatformSounds : MonoBehaviour {
			
	private const int STICK_SOUNDS_COUNT = 2;
	private const int RELEASE_SOUNDS_COUNT = 1;
	private const string STICK_SOUNDS_CLIP_PATH = "Sounds/StickyPlatform/stickyPlatformSound";
	private const string RELEASE_SOUNDS_CLIP_PATH = "Sounds/StickyPlatform/stickyPlatformReleaseSound";
	
	private AudioSource onStickyPlatformCollideAudioSource; 
	
	// Use this for initialization
	void Start () {
		
		onStickyPlatformCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<StickyPlatformController> ().onBallCollide.eventAttachTo += MakeStickySound;
		gameObject.GetComponent<StickyPlatformController> ().onBallRelease.eventAttachTo += MakeReleaseSound;
	}
	
	private void MakeStickySound(){
		
		onStickyPlatformCollideAudioSource.clip = Resources.Load<AudioClip> (STICK_SOUNDS_CLIP_PATH + Random.Range (0, STICK_SOUNDS_COUNT));
		onStickyPlatformCollideAudioSource.Play ();
	}
	
	private void MakeReleaseSound(){
		
		onStickyPlatformCollideAudioSource.clip = Resources.Load<AudioClip> (RELEASE_SOUNDS_CLIP_PATH + Random.Range (0, RELEASE_SOUNDS_COUNT));
		onStickyPlatformCollideAudioSource.Play ();
	}
}

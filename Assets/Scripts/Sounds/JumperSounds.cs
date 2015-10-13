using UnityEngine;
using System.Collections;

public class JumperSounds : MonoBehaviour {
	
	private const int JUMPER_SOUNDS_COUNT = 2;
	private const string PLATFORM_SOUND_CLIP_PATH = "Sounds/Jumper/jumperSound";
	
	private AudioSource onJumperCollideAudioSource; 
	
	// Use this for initialization
	void Start () {
		
		onJumperCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<JumperController> ().onBallCollide.eventAttachTo += this.makePlatformSound;
	}
	
	private void makePlatformSound(){
		
		onJumperCollideAudioSource.clip = Resources.Load<AudioClip> (PLATFORM_SOUND_CLIP_PATH + Random.Range (0, JUMPER_SOUNDS_COUNT));
		onJumperCollideAudioSource.Play ();
	}
}

using UnityEngine;
using System.Collections;

public class MommyBadSounds : MonoBehaviour {
	
	private const int MOMMY_SOUNDS_COUNT = 5;
	private const string MOMMY_SOUNDS_CLIP_PATH = "Sounds/MommyBad/BadLaugh";
	
	private AudioSource onMommyCollideAudioSource; 
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
		
		onMommyCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		levelService.OnBallDestroy.eventAttachTo += makeBadSound;
	}
	
	private void makeBadSound(){

		if (GetComponent<SpriteRenderer> ().enabled) {

			onMommyCollideAudioSource.clip = Resources.Load<AudioClip> (MOMMY_SOUNDS_CLIP_PATH + Random.Range (0, MOMMY_SOUNDS_COUNT));
			onMommyCollideAudioSource.Play ();
		}
	}
}

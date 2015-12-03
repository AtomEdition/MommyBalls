using UnityEngine;
using System.Collections;

public class BallCreatingSounds : MonoBehaviour {

	private const int CREATE_SOUNDS_COUNT = 8;
	private const string CREATE_CLIP_PATH = "Sounds/Ball/ballCreate";

	private AudioSource onCreateBallAudioSource; 

	private readonly LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		levelService.OnBallRelease.eventAttachTo += MakeOnReleaseSound;
		levelService.OnBallDestroy.eventAttachTo += StopOnReleaseSound;

		onCreateBallAudioSource = gameObject.AddComponent<AudioSource> ();
	}

	private void MakeOnReleaseSound(){
		
		onCreateBallAudioSource.clip = Resources.Load<AudioClip> (CREATE_CLIP_PATH + Random.Range(0, CREATE_SOUNDS_COUNT));
		onCreateBallAudioSource.Play ();
	}
		
	private void StopOnReleaseSound(){

		if (onCreateBallAudioSource != null) {
		
			onCreateBallAudioSource.Stop ();
		}
	}
}

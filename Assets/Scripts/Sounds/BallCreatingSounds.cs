using UnityEngine;
using System.Collections;

public class BallCreatingSounds : MonoBehaviour {

	private const int CREATE_SOUNDS_COUNT = 8;
	private const string CREATE_CLIP_PATH = "Sounds/Ball/ballCreate";

	private AudioSource onCreateBallAudioSource; 

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		levelService.OnBallRelease.eventAttachTo += makeOnReleaseSound;
		levelService.OnBallDestroy.eventAttachTo += stopOnReleaseSound;

		onCreateBallAudioSource = gameObject.AddComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void makeOnReleaseSound(){
		
		onCreateBallAudioSource.clip = Resources.Load<AudioClip> (CREATE_CLIP_PATH + Random.Range(0, CREATE_SOUNDS_COUNT));
		onCreateBallAudioSource.Play ();
	}
		
	private void stopOnReleaseSound(){

		if (onCreateBallAudioSource != null) {
		
			onCreateBallAudioSource.Stop ();
		}
	}
}

using UnityEngine;
using System.Collections;

public class BallSounds : MonoBehaviour {

	private const int CREATE_SOUNDS_COUNT = 8;
	private const int DESTROY_SOUNDS_COUNT = 1;
	private const string CREATE_CLIP_PATH = "Sounds/Ball/ballCreate";
	private const string DESTROY_CLIP_PATH = "Sounds/Ball/ballDestroy";

	private AudioSource onCreateBallAudioSource; 
	private AudioSource onDestroyBallAudioSource;

	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		levelService.OnBallRelease.eventAttachTo += makeOnReleaseSound;
		levelService.OnBallDestroy.eventAttachTo += makeOnDestroySound;

		onCreateBallAudioSource = gameObject.AddComponent<AudioSource> ();
		onDestroyBallAudioSource = gameObject.AddComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void makeOnReleaseSound(){
		
		onCreateBallAudioSource.clip = Resources.Load<AudioClip> (CREATE_CLIP_PATH + Random.Range(0, CREATE_SOUNDS_COUNT));
		onCreateBallAudioSource.Play ();
	}
	
	private void makeOnDestroySound(){
		
		onDestroyBallAudioSource.clip = Resources.Load<AudioClip> (DESTROY_CLIP_PATH + Random.Range(0, DESTROY_SOUNDS_COUNT));
		onDestroyBallAudioSource.Play ();
	}
}

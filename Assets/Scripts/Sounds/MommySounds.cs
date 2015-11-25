using UnityEngine;
using System.Collections;

public class MommySounds : MonoBehaviour {
	
	private const int MOMMY_SOUNDS_COUNT = 2;
	private const string MOMMY_SOUNDS_CLIP_PATH = "Sounds/Mommy/mommy";
	
	private AudioSource onMommyCollideAudioSource; 
	private LevelService levelService = Singleton<LevelService>.GetInstance();

	// Use this for initialization
	void Start () {
		
		onMommyCollideAudioSource = gameObject.AddComponent<AudioSource> ();
		levelService.OnBallCatch.eventAttachTo += makeMommySound;
	}	
	
	private void makeMommySound(){
		
		onMommyCollideAudioSource.clip = Resources.Load<AudioClip> (MOMMY_SOUNDS_CLIP_PATH + Random.Range (0, MOMMY_SOUNDS_COUNT));
		onMommyCollideAudioSource.Play ();
	}}

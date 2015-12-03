using UnityEngine;
using System.Collections;

public class BallDestroyingSounds : MonoBehaviour {
	
	private const int DESTROY_SOUNDS_COUNT = 1;
	private const string DESTROY_CLIP_PATH = "Sounds/Ball/ballDestroy";
	
	private AudioSource onDestroyBallAudioSource;

	// Use this for initialization
	void Start () {

		onDestroyBallAudioSource = gameObject.AddComponent<AudioSource> ();	

		gameObject.GetComponent<DestroyBallBehaviour> ().onBallCollide.eventAttachTo += MakeOnDestroySound;
	}
	
	private void MakeOnDestroySound(){
		
		onDestroyBallAudioSource.clip = Resources.Load<AudioClip> (DESTROY_CLIP_PATH + Random.Range(0, DESTROY_SOUNDS_COUNT));
		onDestroyBallAudioSource.Play ();
	}
}

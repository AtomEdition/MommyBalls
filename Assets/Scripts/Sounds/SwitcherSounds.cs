using UnityEngine;
using System.Collections;

public class SwitcherSounds : MonoBehaviour {
	
	private const int SWITCHER_SOUNDS_COUNT = 1;
	private const string SWITCHER_SOUND_CLIP_PATH = "Sounds/Switcher/switcherSound";
	
	private AudioSource onSwitchAudioSource; 
	
	// Use this for initialization
	void Start () {
		
		onSwitchAudioSource = gameObject.AddComponent<AudioSource> ();
		gameObject.GetComponent<SwitcherBehaviour> ().onSwitchEvent.eventAttachTo += MakeSwitcherSound;
	}
	
	private void MakeSwitcherSound(){
		
		onSwitchAudioSource.clip = Resources.Load<AudioClip> (SWITCHER_SOUND_CLIP_PATH + Random.Range (0, SWITCHER_SOUNDS_COUNT));
		onSwitchAudioSource.Play ();
	}
}
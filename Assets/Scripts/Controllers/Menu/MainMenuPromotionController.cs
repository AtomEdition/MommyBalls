using UnityEngine;
using System.Collections;

public class MainMenuPromotionController : MonoBehaviour {

	public Sprite[] sprites;
	public string[] urls;

	private int currentPosition;
	private const float REPEAT_INTERVAL = 1.5F;

	// Use this for initialization
	void Start () {

		currentPosition = Random.Range (0, sprites.Length);
		GetComponent<SpriteRenderer> ().sprite = sprites [currentPosition];
		GetComponent<FollowButtonController> ().url = urls [currentPosition];
		InvokeRepeating ("ChangeSprite", 0, REPEAT_INTERVAL);
	}

	private void ChangeSprite() {

		if (currentPosition < sprites.Length - 1) {
			currentPosition++;
		} else {
			currentPosition = 0;
		}
		GetComponent<SpriteRenderer> ().sprite = sprites [currentPosition];
		GetComponent<FollowButtonController> ().url = urls [currentPosition];
	}
}

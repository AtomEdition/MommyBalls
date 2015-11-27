using UnityEngine;
using System.Collections;

public class MainMenuPromotionController : MonoBehaviour {

	public Sprite[] sprites;
	public string[] urls;

	// Use this for initialization
	void Start () {

		int rnd = Random.Range (0, sprites.Length);
		GetComponent<SpriteRenderer> ().sprite = sprites [rnd];
		GetComponent<FollowButtonController> ().url = urls [rnd];
	}
}

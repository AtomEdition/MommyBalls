using UnityEngine;
using System.Collections;

public class NextLevelButtonAppearance : MonoBehaviour {

	public Sprite enabledSprite;
	public Sprite disabledSprite;

	public void SetCondition(bool isEnabled) {

		GetComponent<SpriteRenderer> ().sprite = isEnabled ? enabledSprite : disabledSprite;
	}
}

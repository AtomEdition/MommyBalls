using UnityEngine;
using System.Collections;

public class ButtonPlayClickListener : MonoBehaviour {

	private const string BUTTON_PLAY_PREFIX = "buttonPlay-";
	private const string LOAD_LEVEL_PREFIX = "Level-";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider != null)

				if (hit.collider.gameObject.name.Contains (BUTTON_PLAY_PREFIX))
				{
					string loadLevelName = hit.collider.gameObject.name.Replace(BUTTON_PLAY_PREFIX, LOAD_LEVEL_PREFIX); 
					
					Application.LoadLevel (loadLevelName);
				}
		}
	}
}

using UnityEngine;
using System.Collections;

public class ButtonPlayClickListener : MonoBehaviour {

	private const string buttonPlayPrefix = "buttonPlay-";
	private const string loadLevelPrefix = "Level-";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {

			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider != null)

				if (hit.collider.gameObject.name.Contains (buttonPlayPrefix))
				{
					string loadLevelName = hit.collider.gameObject.name.Replace(buttonPlayPrefix, loadLevelPrefix); 
					
					Application.LoadLevel (loadLevelName);
				}
		}

	}
}

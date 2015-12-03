using UnityEngine;
using System.Collections;

public class FollowButtonController : MonoBehaviour {

	public string url;
	readonly InputService inputService = Singleton<InputService>.GetInstance();
	
	// Update is called once per frame
	void Update () {
		
		ToUrlListener ();
	}

	private void ToUrlListener() {
		
		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (hit.collider != null
			    && hit.collider.gameObject == this.gameObject) {
				
				Application.OpenURL(url);
			}
		}
	}
}

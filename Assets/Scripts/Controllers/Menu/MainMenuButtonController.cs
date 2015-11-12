using UnityEngine;
using System.Collections;

public class MainMenuButtonController : MonoBehaviour {

	public int sceneIndex;
	public string buttonText;
	private InputService inputService = Singleton<InputService>.GetInstance();
	public float buttonAngle = 30F;

	// Use this for initialization
	void Start () {
		
		SetButtonText ();
		SetButtonAngle ();
	}
	
	// Update is called once per frame
	void Update () {
		
		ToSceneListener ();
	}
	
	private void SetButtonText() {

		if (buttonText != null && buttonText.Length != 0) {
			TextMesh text = GetComponentInChildren<TextMesh> ();
			text.text = buttonText;
		}
	}
	
	private void SetButtonAngle (){

		float index = Random.Range(-buttonAngle, buttonAngle);
		gameObject.transform.eulerAngles = new Vector3 (0, 0, index);
	}

	private void ToSceneListener() {
		
		if (inputService.IsInputDown()) {
			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (hit.collider != null
			    && hit.collider.gameObject == gameObject) {
				
				Application.LoadLevel(sceneIndex);
			}
		}
	}
}

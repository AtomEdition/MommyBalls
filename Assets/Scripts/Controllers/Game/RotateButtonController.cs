using UnityEngine;
using System.Collections;

public class RotateButtonController : MonoBehaviour {

	public GameObject[] attachedObjects = {};

	public float rotationAngleTo = 0;

	public float rotationMultiplier = 1;
	private const float BASE_ROTATION_POWER = 0.8F;
	private float currentRotationPower;

	private InputService inputService = Singleton<InputService>.GetInstance();

	// Use this for initialization
	void Start () {
	
		this.currentRotationPower = BASE_ROTATION_POWER * rotationMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
	
		OnContinuousClick ();
	}

	private void OnContinuousClick() {

		if (inputService.IsInputHold ()) {

			
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			foreach (GameObject attachedObject in attachedObjects) {

				float currentRotation = attachedObject.transform.eulerAngles.z;

				if (hit.collider != null
				    && hit.collider.gameObject == this.gameObject)
				    if ((currentRotation <= rotationAngleTo && rotationMultiplier > 0)
					   || (currentRotation >= rotationAngleTo && rotationMultiplier < 0)) {

					currentRotation += currentRotationPower;
					attachedObject.gameObject.transform.rotation = Quaternion.Euler (0, 0, currentRotation);
				}
			}
		}
	}
}

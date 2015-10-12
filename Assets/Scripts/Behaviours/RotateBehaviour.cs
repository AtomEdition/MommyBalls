using UnityEngine;
using System.Collections;

public class RotateBehaviour : MonoBehaviour {

	private const float BASE_ROTATION_POWER = 0.8F;
	public float rotationPowerMultiplier = 1;
	private float currentRotationPower;

	// Use this for initialization
	void Start () {

		currentRotationPower = BASE_ROTATION_POWER * rotationPowerMultiplier;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float currentRotation = this.gameObject.transform.eulerAngles.z;
		currentRotation += currentRotationPower;
		this.gameObject.transform.rotation = Quaternion.Euler (0, 0, currentRotation);
	}
}

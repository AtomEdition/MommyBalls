using UnityEngine;
using System.Collections;

public class RotateBehaviour : MonoBehaviour {

	private float currentRotation = 0F;
	private const float BASE_ROTATE_POWER = 0.8F;
	private float currentRotatePower;
	public float rotatePowerMultiplier = 1;

	// Use this for initialization
	void Start () {

		currentRotatePower = BASE_ROTATE_POWER * rotatePowerMultiplier;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentRotation += currentRotatePower;
		this.transform.rotation = Quaternion.Euler (0, 0, currentRotation);
	}
}

using UnityEngine;
using System.Collections;

public class RotateBehaviour : MonoBehaviour {

	private float rotation = 0F;
	private const float rotatePower = 0.8F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		rotation += rotatePower;
		this.transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
}

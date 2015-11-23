using UnityEngine;
using System.Collections;

public class LevelChoosingBorderController : MonoBehaviour {

	public GameObject levelChoosingCamera;
	public const float RANGE_FROM_CENTER = 5.32F;
	// Use this for initialization
	void Start () {

		Vector3 vec = levelChoosingCamera.transform.position;
		vec.y += RANGE_FROM_CENTER;
		gameObject.transform.position = vec;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

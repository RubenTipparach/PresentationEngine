using UnityEngine;
using System.Collections;

public class background_paralx : MonoBehaviour {

	Camera main;

	[SerializeField]
	private float paralaxFactor = 0.01f;

	float paralaxPos = 0;

	Vector3 staticPos;

	// Use this for initialization
	void Start () {
		main = Camera.main;
		staticPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		//offset 

		paralaxPos = main.transform.position.x  - main.transform.position.x * paralaxFactor;

		transform.position = staticPos + Vector3.right * paralaxPos;
	}
}

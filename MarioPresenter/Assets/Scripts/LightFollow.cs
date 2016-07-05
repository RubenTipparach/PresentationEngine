using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {

    [SerializeField]
    Transform followThis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(followThis != null)
        {
            transform.position = new Vector3(followThis.position.x, followThis.position.y, transform.position.z);
        }
	}
}

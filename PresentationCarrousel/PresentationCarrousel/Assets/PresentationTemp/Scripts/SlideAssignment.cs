using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAssignment : MonoBehaviour {

    public Texture2D slideOverlay;
    public Texture2D slideMain;

    [SerializeField]
    Transform child1;

    [SerializeField]
    Transform child2;

    [SerializeField]
    Shader shader1;

    [SerializeField]
    Shader shader2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AssignChildrenMaterial()
    {
        if (slideOverlay != null)
        {
            child1.GetComponent<MeshRenderer>().material = new Material(shader1);
            child1.GetComponent<MeshRenderer>().material.mainTexture = slideOverlay;
        }

        child2.GetComponent<MeshRenderer>().material = new Material(shader2);
        child2.GetComponent<MeshRenderer>().material.mainTexture = slideMain;
    }
}

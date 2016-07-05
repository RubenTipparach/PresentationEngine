using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    [SerializeField]
    string loadLevel;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(loadLevel);
	}
}

using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    [SerializeField]
    GameObject enabler;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	//usually this would trigger stuff to happen.
	void OnTriggerEnter2D(Collider2D other)
	{
        if(enabler != null)
        {
            enabler.SetActive(true);
        }

        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
        Destroy(gameObject);
	}
}

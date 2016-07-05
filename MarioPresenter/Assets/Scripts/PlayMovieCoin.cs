using UnityEngine;
using System.Collections;

public class PlayMovieCoin : MonoBehaviour {

	[SerializeField]
	Renderer movieRenderer;

	void OnTriggerEnter2D(Collider2D other)
	{
		((MovieTexture)movieRenderer.material.mainTexture).Play();
		movieRenderer.GetComponent<AudioSource>().Play();
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
        Destroy(gameObject);
	}
}

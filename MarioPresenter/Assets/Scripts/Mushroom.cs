using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

	private Vector2 currentVelocity;

	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(1,5);
	}
	
	void Update () {
		currentVelocity = GetComponent<Rigidbody2D>().velocity;

	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.name == "Obstacle"){
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * currentVelocity.x, 0);

		}
		if (c.collider.name == "Mario") {
			Destroy(this.gameObject);
		}
	}
}

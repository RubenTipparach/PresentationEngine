using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {

	public float speed = 1.0f;
	public float jumpSpeed = 0.5f;
	public LayerMask groundLayer;
	public Transform boxOff;
	public Transform mush;
	
	private Animator marioAnimator;
	private Transform gCheck;
	private float scaleX = 1.0f;
	private float scaleY = 1.0f;
	private bool isBig;

	private float lastXpos;

	void Start () {
		marioAnimator = GetComponent<Animator>();
		gCheck = transform.FindChild("GCheck");
	
	}

	/// <summary>
	/// Move the camera here.
	/// </summary>
	void Update()
	{
		float currentXpos = transform.position.x;

		var cm = Camera.main.transform;

		cm.position = Vector3.Lerp(
			cm.position,
			new Vector3(transform.position.x, cm.position.y, cm.position.z), 
			0.1f);

		lastXpos = transform.position.x;
    }

	/// <summary>
	/// For the physics related stuff.
	/// </summary>
	void FixedUpdate () {
		float mSpeed = Input.GetAxis("Horizontal");
		marioAnimator.SetFloat("Speed", Mathf.Abs(mSpeed));
		bool isTouched = Physics2D.OverlapPoint(gCheck.position, groundLayer);


		if (Input.GetKey(KeyCode.Space)){

			if (isTouched){
				Debug.Log("Jump!");
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
				isTouched = false;
			}
		}
		marioAnimator.SetBool("isTouched", isTouched);


		if (mSpeed > 0){
			transform.localScale = new Vector2(scaleX, scaleY);
		}
		else if (mSpeed < 0){
			transform.localScale = new Vector2(-scaleX, scaleY);
		}

		this.GetComponent<Rigidbody2D>().velocity = new Vector2(mSpeed * speed, this.GetComponent<Rigidbody2D>().velocity.y);
	}

	/// <summary>
	/// Called when [collision enter2 d].
	/// Most of these I'll ignore for now. Presentation thingy will be improved upon over time.
	/// </summary>
	/// <param name="c">The c.</param>
	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.name == "Box"){
			Transform newBox = Instantiate(boxOff, c.transform.position, Quaternion.identity) as Transform;
			Transform newMush = Instantiate(mush, new Vector2(c.transform.position.x, c.transform.position.y + 1), 
			                                									Quaternion.identity) as Transform;
			Destroy(c.gameObject);
		}
		if (c.collider.name == "Mush(Clone)") {
			isBig = true;
			scaleX = 1.5f;
			scaleY = 1.5f;
			transform.localScale = new Vector2(scaleX, scaleY);
			
		}

		// plant
		if (c.collider.name == "Plant" || c.collider.name == "Mob") {
			if(!isBig){
				Application.LoadLevel(0);
			}
			else{

				scaleX = 1.0f;
				scaleY = 1.0f;
				transform.localScale = new Vector2(scaleX, scaleY);
				StartCoroutine(Tiny());

			}
		}

		if (c.collider.name == "Head") {
			Debug.Log("aaa");
			Destroy(c.transform.root.transform.gameObject);	

		}
		if (c.collider.name == "Coin") {
			Destroy(c.gameObject);	

		}

	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	public IEnumerator Tiny() {
		yield return new WaitForSeconds(1.0f);
		isBig = false;
	}
}

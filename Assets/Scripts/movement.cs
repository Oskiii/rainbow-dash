using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	Rigidbody2D rib;
	bool facingRight;
	public float maxSpeed;
	public float moveSpeed;

	public float jumpForce;
	public Transform groundCheck1;
	public Transform groundCheck2;
	public LayerMask whatIsGround;

	public float jumpRollSpeed;
	private bool jumpRolling = false;

	void Start () {
		rib = GetComponent<Rigidbody2D> ();
		facingRight = true;
	}

	void FixedUpdate () {

		bool move = Input.GetKey(KeyCode.Mouse0);

		rib.velocity = new Vector2 (moveSpeed * maxSpeed * Mathf.Abs(transform.localScale.x), rib.velocity.y);

		bool grounded1 = Physics2D.OverlapPoint (groundCheck1.transform.position, whatIsGround);
		bool grounded2 = Physics2D.OverlapPoint (groundCheck2.transform.position, whatIsGround);
		if (move &&  (grounded1 == true || grounded2 == true)) {

			rib.AddForce(Vector3.up * jumpForce);
			StartCoroutine("JumpRoll");
		}

	}

	void Update(){
		if (rib.velocity.x < moveSpeed) {
			print ("lose");
			transform.position = new Vector2(0f, 1f);
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator JumpRoll() {

		transform.rotation = Quaternion.identity;
		Quaternion fromAngle = transform.rotation;
		Quaternion toAngle = Quaternion.Euler (transform.eulerAngles + Vector3.back * 120);
		for (float t = 0f; t < 1f; t += Time.deltaTime/(jumpForce/(rib.gravityScale*400f))) {
			transform.rotation = Quaternion.Lerp (fromAngle, toAngle, t);
			yield return null;
		}
		transform.rotation = Quaternion.identity;
	}

}

﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	Rigidbody2D rib;
	bool facingRight;
	public float moveSpeed;

	public float jumpForce;
	public Transform groundCheck1;
	public Transform groundCheck2;
	public LayerMask whatIsGround;

	public float jumpRollSpeed;
	private bool jumpRolling = false;

	public GameObject levelStartPosition;

	void Start () {
		rib = GetComponent<Rigidbody2D> ();
		facingRight = true;
	}

	void FixedUpdate () {

		bool jump = Input.GetKey(KeyCode.Mouse0);

		rib.velocity = new Vector2 (moveSpeed * Mathf.Abs(transform.localScale.x), rib.velocity.y);

		bool grounded1 = Physics2D.OverlapPoint (groundCheck1.transform.position, whatIsGround);
		bool grounded2 = Physics2D.OverlapPoint (groundCheck2.transform.position, whatIsGround);
		if (jump &&  (grounded1 == true || grounded2 == true)) {
			rib.velocity = new Vector2(rib.velocity.x, 0f);
			rib.AddForce(Vector3.up * jumpForce);
			StartCoroutine("JumpRoll");
		}

	}

	void Update(){
		if (rib.velocity.x < moveSpeed) {
			print ("lose");
			transform.position = levelStartPosition.transform.position;
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

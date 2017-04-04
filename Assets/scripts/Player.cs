using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D body;
	private Animator myAnimator;
	[SerializeField]
	private float speed;
	private bool isRight;
	// Use this for initialization
	void Start () {
		isRight = true;
		body = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		Move (horizontal);
		Flip (horizontal);
	}

	private void Move(float horizontal){
		body.velocity = new Vector2(horizontal * speed, body.velocity.y); // x = -1, y = 0
		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
	}

	private void Flip(float horizontal){
		if ((horizontal > 0 && !isRight) || (horizontal < 0 && isRight)) {
			isRight = !isRight;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}
}

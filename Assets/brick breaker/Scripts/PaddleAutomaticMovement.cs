using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAutomaticMovement : MonoBehaviour {

	public GameObject ball;
	private Rigidbody2D rb;
	float speed = 0.005f;

	void Start() {
		rb = ball.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		if(rb.velocity.y < 0) {
				speed+=0.005f;
				transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, ball.transform.position.x, speed), -3.35f, 0);
				if(transform.position.x > 2.3) {
					transform.position = new Vector2(2.3f, -3.35f);
				}
				if(transform.position.x < -2.3) {
					transform.position = new Vector2(-2.3f, -3.35f);
				}
		}else {
			speed = 0;
		}
	}
}

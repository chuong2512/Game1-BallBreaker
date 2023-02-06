using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

	public GameObject ball;

    void Update () {
        if (Input.GetMouseButtonDown(0) && Vars.canShootTheBall) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.y > 5) {//Not to react on click if user presses pause button or something from upper menu
                return;
            }

            if (ball != null) {
                ball.transform.parent = null;
                ball.GetComponent<Rigidbody2D>().AddForce(transform.up * 800);
            }else {
                ball = GameObject.Find("ball");
                ball.transform.parent = null;
                ball.GetComponent<Rigidbody2D>().AddForce(transform.up * 800);
            }

            Vars.canShootTheBall = false;
        }
		Vector3 v3 = Input.mousePosition;
		v3.z = 10.0f;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		
		transform.position = new Vector2 (v3.x, -3.35f);

        if (v3.x > 2.35f) {
            transform.position = new Vector2(2.35f, -3.35f);
        }

        if (v3.x < -2.35f) {
            transform.position = new Vector2(-2.35f, -3.35f);
        }



    }
}

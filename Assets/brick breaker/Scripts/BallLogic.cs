using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour {

	private Rigidbody2D rb;
	private float ballStuckYTimer = 0;
	private float ballStuckYPos = 0;

    private float ballStuckXTimer = 0;
    private float ballStuckXPos = 0;
	public Sprite[] ballSprites;

	void Start() {
		BallColorAndSprite ();
		rb = GetComponent<Rigidbody2D> ();
        Vars.numberOfBalls++;
	}

	void Update() {
		if(Vars.canShootTheBall) return;

		if ((Mathf.Round(transform.position.y * 10f) / 10f) != (Mathf.Round(ballStuckYPos * 10f) / 10f)) {
			ballStuckYPos = transform.position.y;
            ballStuckYTimer = 0;
		} else {
            ballStuckYTimer += Time.deltaTime;
			if (ballStuckYTimer >= 5) {
				rb.AddForce (new Vector2(0, 50));
                ballStuckYTimer = 0;
			}
		}

        if ((Mathf.Round(transform.position.x * 10f) / 10f) != (Mathf.Round(ballStuckXPos * 10f) / 10f)) {
			ballStuckXPos = transform.position.x;
            ballStuckXTimer = 0;
		} else {
            ballStuckXTimer += Time.deltaTime;
			if (ballStuckXTimer >= 5) {
				rb.AddForce (new Vector2(50, 0));
                ballStuckYTimer = 0;
			}
		}
	}


	public void BallColorAndSprite() {
		SpriteRenderer sp = GetComponent<SpriteRenderer> ();
		sp.sprite = ballSprites [0];
		if (PlayerPrefs.GetString ("selectedBall").Equals ("white")) {
			sp.color = new Color32 (255, 255, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("green")) {
			sp.color = new Color32 (0, 255, 44, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("blue")) {
			sp.color = new Color32 (0, 128, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("pink")) {
			sp.color = new Color32 (251, 0, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("red")) {
			sp.color = new Color32 (255, 0, 0, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("yellow")) {
			sp.color = new Color32 (255, 255, 0, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("brown")) {
			sp.color = new Color32 (136, 84, 11, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("silver")) {
			sp.color = new Color32 (192, 192, 192, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("aqua")) {
			sp.color = new Color32 (0, 255, 255, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("purple")) {
			sp.color = new Color32 (128, 0, 128, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("olive")) {
			sp.color = new Color32 (128, 128, 0, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("violet")) {
			sp.color = new Color32 (138, 43, 226, 255);
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("football")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [1];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("basketball")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [2];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("golf")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [3];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("beachVolleyball")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [4];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("volleyball")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [5];
		}else if (PlayerPrefs.GetString ("selectedBall").Equals ("tennis")) {
			sp.color = new Color32 (255, 255, 255, 255);
			sp.sprite = ballSprites [6];
		}
	}
}
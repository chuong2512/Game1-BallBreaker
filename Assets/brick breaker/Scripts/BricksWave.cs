using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BricksWave : MonoBehaviour {

	private int wave = 1;
	private TextMesh waveText;
	private AudioSource brickHitSound;

	void Start() {
		brickHitSound = GameObject.Find ("brickHitSound").GetComponent<AudioSource> ();
		if (transform.Find ("brickWaveText") != null) {
			waveText = transform.Find ("brickWaveText").GetComponent<TextMesh> ();

			if (Vars.level < 10) {
				wave = Random.Range (1, 3);
			} else {
				wave = Random.Range ((int)(Vars.level / 5), (int)(Vars.level / 2));
			}
			waveText.text = wave.ToString ();
		}


		if(this.gameObject.name.Contains("brick")) {
			ColorBrick ();
		}
	}
		
	void OnCollisionEnter2D(Collision2D col) {
		if (!brickHitSound.isPlaying) {
			brickHitSound.Play ();
		}
		wave--;
		ColorBrick ();
		waveText.text = wave.ToString();
		if (wave <= 0) {
            GameObject[] remainigBricksOnTheScene = GameObject.FindGameObjectsWithTag("object");
            if(remainigBricksOnTheScene.Length == 1) {
                Vars.newWaveTimer = 0;
            }
            Vars.score++;
            GameObject.Find("scoreText").GetComponent<Text>().text = "SCORE \n" + Vars.score;
            if(Vars.score > PlayerPrefs.GetInt("bestScore")) {
                PlayerPrefs.SetInt("bestScore", Vars.score);
            }
			Destroy (this.gameObject);
		}
	}

	public void ColorBrick() {
		if (wave <= 30) {
			GetComponent<SpriteRenderer> ().color = new Color (1, (1 - ((float)wave / 30)), 0);
		} else if (wave <= 60) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 0, (float)(wave - 30) / 30);
		} else {
			float redColorValue = 1-(((float)wave - 60) / 30);
			if (redColorValue < 1) {
				GetComponent<SpriteRenderer> ().color = new Color (redColorValue, 0, 1);
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1, 0, 1);
			}
		}
	}
}
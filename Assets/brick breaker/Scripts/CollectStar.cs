using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStar : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("ball")) {
			PlayerPrefs.SetInt ("numberOfStars", PlayerPrefs.GetInt ("numberOfStars") + 1);
			GameObject.Find ("starCollectedSound").GetComponent<AudioSource> ().Play ();

            GameObject[] remainigBricksOnTheScene = GameObject.FindGameObjectsWithTag("object");
            if (remainigBricksOnTheScene.Length == 1) {
                Vars.newWaveTimer = 0;
            }

            Destroy (this.gameObject);
		}
	}
}

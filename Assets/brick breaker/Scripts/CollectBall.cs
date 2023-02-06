using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name.Contains ("ball")) {
			GameObject.Find ("ballCollectSound").GetComponent<AudioSource> ().Play ();
			//Vars.numberOfBalls++;

            GameObject newBall = Instantiate(Resources.Load<GameObject>("ball"), transform.position, Quaternion.identity) as GameObject;
            newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(500, 800), Random.Range(500, 800)));
            newBall.name = "ball";

            GameObject[] remainigBricksOnTheScene = GameObject.FindGameObjectsWithTag("object");
            if (remainigBricksOnTheScene.Length == 1) {
                Vars.newWaveTimer = 0;
            }

            Destroy (this.gameObject);
		}
	}
}

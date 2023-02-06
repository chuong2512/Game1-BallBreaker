using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour {

    public GameObject nextWave;
    private Text nextWaveTimer;
	public Sprite[] ballSprites;

	void Start() {
        nextWaveTimer = nextWave.GetComponent<Text>();
	}

	void Update() {
        Vars.newWaveTimer -= Time.deltaTime;
        nextWaveTimer.text = "NEW WAVE \n" + (int)Vars.newWaveTimer;

        if (Vars.newWaveTimer <= 0) {
            Vars.newWaveTimer = 11;
			Vars.newWaveOfBricks = false;
			GameObject[] objects = GameObject.FindGameObjectsWithTag ("object");
			foreach (GameObject sceneObjects in objects) {
				sceneObjects.GetComponent<MoveDownObjects> ().enabled = true;
				sceneObjects.GetComponent<MoveDownObjects> ().MoveObjectkDown ();
			}
			GetComponent<ObjectPlacement> ().PlaceNewObjectsOnTheScene ();

			Vars.level++;
		}

	}
}

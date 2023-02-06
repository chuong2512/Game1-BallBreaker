using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        Vars.numberOfBalls--;
        Destroy(collision.gameObject);
        if(Vars.numberOfBalls == 0) {
            GameObject.Find("GameManager").GetComponent<Menus>().ShowGameoverMenu();
        }
    }
}

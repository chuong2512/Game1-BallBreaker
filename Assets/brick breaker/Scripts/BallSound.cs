using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

    private AudioSource bounceSound;
    private AudioSource wallHitSound;

    private void Start() {
        bounceSound = GameObject.Find("bounceSound").GetComponent<AudioSource>();
        wallHitSound = GameObject.Find("wallHitSound").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name.Equals("paddle")) {
            bounceSound.Play();
        } else if(collision.gameObject.name.Contains("border")) {
            wallHitSound.Play();
        }
    }
}

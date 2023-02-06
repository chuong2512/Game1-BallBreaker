using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

	public GameObject mainBall;
	public GameObject mainMenuBouncingBall;
	public GameObject mainMenu;
	public GameObject ballsShop;
	public GameObject upperMenu;
	public GameObject gameoverMenuUI;
	public GameObject pauseMenuUI;
	public GameObject bestScoreMainMenu;
	public GameObject paddle;

	public GameObject numberOfStarsMainMenu;
	public GameObject numberOfStarsShop;
	private AudioSource buttonClickSound;

	void Start() {
		numberOfStarsMainMenu.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();

		bestScoreMainMenu.GetComponent<Text> ().text = "BEST\n" + PlayerPrefs.GetInt ("bestScore").ToString ();

		buttonClickSound = GameObject.Find ("buttonClickSound").GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("restartTheGame") == 1) {
			PlayerPrefs.SetInt ("restartTheGame", 0);
            StartTheGame();

        }
	}

    public void StartTheGame() {
        buttonClickSound.Play();
        upperMenu.SetActive(true);
        mainMenuBouncingBall.SetActive(false);
        mainBall.SetActive(true);
        mainMenu.SetActive(false);
        paddle.SetActive(true);
        GetComponent<WaveTimer>().enabled = true;
        GetComponent<ObjectPlacement>().enabled = true;
        GameObject.Find("paddle").GetComponent<PaddleMovement>().enabled = true;
        Vars.canShootTheBall = true;
    }

	public void BallsShop() {
		numberOfStarsShop.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();
		buttonClickSound.Play ();
		ballsShop.SetActive (true);
	}
	public void ExitBallsShop (){
		numberOfStarsMainMenu.GetComponent<Text> ().text = PlayerPrefs.GetInt ("numberOfStars").ToString();
		buttonClickSound.Play ();
		ballsShop.SetActive (false);
	}

	public void ExitToMainMenu() {
		buttonClickSound.Play ();
		Vars.RestartAllVariables ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void ShowGameoverMenu () {
        GetComponent<WaveTimer>().enabled = false;
        GameObject.Find ("gameOverSound").GetComponent<AudioSource> ().Play ();
        GameObject.Find("paddle").GetComponent<PaddleMovement>().enabled = false;
        gameoverMenuUI.SetActive (true);
	}

	public void ShowPauseMenu() {
		GameObject.Find ("pauseButtonSound").GetComponent<AudioSource> ().Play ();
        GameObject.Find("paddle").GetComponent<PaddleMovement>().enabled = false;
		Time.timeScale = 0;
		pauseMenuUI.SetActive (true);
	}

	public void HidePauseMenu() {
		buttonClickSound.Play ();
		GetComponent<WaveTimer> ().enabled = true;
        GameObject.Find("paddle").GetComponent<PaddleMovement>().enabled = true;
        Time.timeScale = 1;
		pauseMenuUI.SetActive (false);
	}

	public void ContinueGame() {
		Debug.Log ("Put your code that shows rewarded ad and than call method ContinueGame() from Menus.cs script on line 89");
        Vars.canShootTheBall = true;
        Vars.newWaveTimer = 11;
        GetComponent<WaveTimer>().enabled = true;
        buttonClickSound.Play ();
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("object");
		foreach (GameObject sceneObject in objects) {
			if (sceneObject.GetComponent<Rigidbody2D> ().position.y < -0.5f) {
				Destroy (sceneObject);
			}
		}

        GameObject newBall = Instantiate(Resources.Load<GameObject>("ball"), new Vector2(paddle.transform.position.x, -2.97f), Quaternion.identity) as GameObject;
        newBall.transform.parent = paddle.transform;
        newBall.name = "ball";
        gameoverMenuUI.SetActive (false);
        GameObject.Find("paddle").GetComponent<PaddleMovement>().enabled = true;

    }

	public void SpeedUpGame() {
		buttonClickSound.Play ();
		Time.timeScale = 5f;
		GameObject.Find ("speedUpButton").SetActive (false);
	}

	public void RestartGame () {
		PlayerPrefs.SetInt ("restartTheGame", 1);
		Vars.RestartAllVariables ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

    public void ExitTheGame () {
        buttonClickSound.Play();
        Application.Quit();
    }

}
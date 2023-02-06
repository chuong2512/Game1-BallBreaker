using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour {

    public static bool canShootTheBall = true;
    public static int score = 0;
	public static int level = 1;
	public static int numberOfBalls = 0;
	public static bool canContinue = true;
	public static bool newWaveOfBricks = false;
    public static float newWaveTimer = 11;

	public static void RestartAllVariables() {
        Vars.canShootTheBall = true;
        Vars.score = 0;
        Vars.level = 1;
		Vars.numberOfBalls = 0;
		Vars.canContinue =  true;
		Vars.newWaveOfBricks = false;
        Vars.newWaveTimer = 11;
	}
}

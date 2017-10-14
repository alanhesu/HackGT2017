using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public enum State
    {
        Planning,
        Results,
        Flying,
        Config
    }
    public static float cash;
    public static int score;
    public static State state;
    public static float launchHeight;

	// Use this for initialization
	void Start () {
        cash = 0;
        score = 0;
        launchHeight = 10;
        state = State.Planning;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.Planning)
        {

        }
        else if (state == State.Flying)
        {

        }
        else if (state == State.Results)
        {

        }
	}
}

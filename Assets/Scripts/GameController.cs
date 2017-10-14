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

    public Dodo dodo;    

	// Use this for initialization
	void Start () {
        cash = 0;
        score = 0;
        launchHeight = 100;
        state = State.Planning;
        //dodo = GameObject.Instantiate(Resources.Load("Dodo")) as Dodo;
        dodo = Instantiate(dodo, transform.position, transform.rotation);        
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

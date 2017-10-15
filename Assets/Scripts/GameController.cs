using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static float startVel;

    public Text AltitudeText;

    public GameObject dodo;
    
	// Use this for initialization
	void Start () {
        cash = 0;
        score = 0;
        launchHeight = 100;
        startVel = 10;
        state = State.Flying;
        Physics.gravity = new Vector3(0, -5, 0);
        //dodo = GameObject.Instantiate(Resources.Load("Dodo")) as Dodo;
        dodo = Instantiate(dodo, transform.position, transform.rotation) as GameObject;        
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.Planning)
        {

        }
        else if (state == State.Flying)
        {
            AltitudeText.text = string.Format("Altitude: {0:0.000}\nDistance: {1:0.000}", dodo.transform.position.y, dodo.transform.position.z);
            //Debug.Log(dodo.transform.position.y);
            //AltitudeText.text = dodo.transform.position.y.ToString();
        }
        else if (state == State.Results)
        {
            
        }
	}
}

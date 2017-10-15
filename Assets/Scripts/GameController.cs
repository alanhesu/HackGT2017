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
    public GameObject tree;

    public Tree[] trees = new Tree[10];
    
	// Use this for initialization
	void Start () {
        cash = 0;
        score = 0;
        launchHeight = 100;
        startVel = 50;
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
            AltitudeText.text = string.Format("Altitude: {0:0.000}\nDistance: {1:0.}", dodo.transform.position.y, dodo.transform.position.z);
            if (dodo.transform.position.y <= 0)
            {
                state = State.Results;
            }
            //Debug.Log(dodo.transform.position.y);
            //AltitudeText.text = dodo.transform.position.y.ToString();
        }
        else if (state == State.Results)
        {

        }
	}

    void SpawnTree()
    {
        float zSpacingMin = 2;
        foreach (Tree t in trees)
        {
            t = Instantiate(tree,
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public enum State
    {
        Planning,
        Results,
        Flying,
        Config
    }
    public static float cash = 0;
    public static State state;
    public static float launchHeight = 10;
    public static float startVel;
    public static int numTree;
    public static GameController control;

    public Text AltitudeText;

    public GameObject dodo;
    public GameObject tree;

    public static float thrust = 2;
    public static float stamMult = .5f;

    private GameObject[] trees;

    public static int numUpStam = 1;
    public static int numUpThrust = 1;
    public static int numUpHeight = 1;

    // Use this for initialization

    void Awake()
    {
        //DontDestroyOnLoad(this);
        /*
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        /*
        if (control == null)
        {
            DontDestroyOnLoad(transform.gameObject);
        } else if (control != this)
        {
            Destroy(gameObject);
        }*/
    }
	void Start () {
        startVel = 50;
        numTree = 20;
        trees = new GameObject[numTree];
        state = State.Flying;
        Physics.gravity = new Vector3(0, -6, 0);
        //dodo = GameObject.Instantiate(Resources.Load("Dodo")) as Dodo;
        SpawnTree();
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
            UpdateTrees();
            if (dodo.transform.position.y <= 0)
            {
                //state = State.Results;
            }
            //Debug.Log(dodo.transform.position.y);
            //AltitudeText.text = dodo.transform.position.y.ToString();
        }
	}

    void SpawnTree()
    {
        Random rand = new Random();

        float xSpacing = 200;

        float zSpacingMin = 30 / (numTree / 10);
        float zSpacingAvg = 30 / (numTree / 10);

        float treePosX = 0;
        float treePosZ = 100;

        float treeRotY = 0;

        for (int i = 0; i < numTree; i++)
        {
            treePosX = Random.Range(0, xSpacing) - xSpacing / 2;
            treePosZ += Random.Range(0, zSpacingAvg) + zSpacingMin;
            treeRotY = Random.Range(0, 360);

            Vector3 pos = new Vector3(treePosX, 0, treePosZ);
            Quaternion rot = Quaternion.Euler(0, treeRotY, 0);
            trees[i] = Instantiate(tree, pos, rot) as GameObject;
            //Debug.Log("Spawn tree " + (i + 1));
        }
    }
    
    void UpdateTrees()
    {
        float xSpacing = 200;

        float zSpacingMin = 30 / (numTree / 10);
        float zSpacingAvg = 30 / (numTree / 10);

        float newPosX;
        float newPosZ;
        float newRotY;
        for (int i = 0; i < numTree; i++)
        {
            newPosX = 0;
            newPosZ = trees[i].transform.position.z;
            newRotY = 0;
            if (trees[i].transform.position.z < dodo.transform.position.z -10)
            {
                newPosX = Random.Range(0, xSpacing) - xSpacing / 2;
                newPosZ += (zSpacingMin + zSpacingAvg/2) * numTree + Random.Range(0, zSpacingAvg) - zSpacingAvg/2;
                newRotY = Random.Range(0, 360);
                trees[i].transform.position = new Vector3(newPosX, 0, newPosZ);
                trees[i].transform.rotation = Quaternion.Euler(0, newRotY, 0);
            }
        }
    }

    public static void upgradeStam()
    {
        if (cash - numUpStam * 300 >= 0)
        {
            cash -= 300 * numUpStam;
            stamMult *= .7f;
            numUpStam++;
        }
    }

    public static void upgradeThrust()
    {
        if (cash - numUpThrust * 300 >= 0)
        {
            cash -= 300 * numUpThrust;
            thrust += .5f;
            numUpThrust++;
        }
    }

    public static void upgradeHeight()
    {
        if (cash - numUpHeight * 300 >= 0)
        {
            cash -= 300 * numUpHeight;
            launchHeight += 10f;
            numUpHeight++;
        }
    }
}

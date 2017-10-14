using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodo : MonoBehaviour {    
    private float timer = 0;
    private float HandRightPrevZ;
    private float HandLeftPrevZ;
    private float timerPeriod = .05f;
    private Rigidbody rb;
    public float thrust;

	// Use this for initialization
	void Start () {
        StartFlying(GameController.launchHeight);
        rb = GetComponent<Rigidbody>();
        rb.mass = 10;
        thrust = 100;
	}
	
	// Update is called once per frame
	void Update () {        
        /*
        timer += Time.deltaTime;       
        if (timer >= timerPeriod && KinectManager.instance.IsAvailable)
        {
            if ((HandRightPrevZ - KinectManager.instance.HandRight.Z > .5f)
                && (HandLeftPrevZ - KinectManager.instance.HandLeft.Z > .5f))
            {
                rb.AddForce(0, 0, thrust, ForceMode.Impulse);
                HandRightPrevZ = KinectManager.instance.HandRight.Z;
                HandLeftPrevZ = KinectManager.instance.HandLeft.Z;
                timer = 0;
            }
        } */
        if (Input.GetKeyDown("up"))
        {
            rb.AddForce(0, thrust, 0, ForceMode.Impulse);
        }       
	}

    void StartFlying(float startHeight)
    {
        transform.position = new Vector3(0, startHeight, 0);        
    }
}

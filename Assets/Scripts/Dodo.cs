using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodo : MonoBehaviour {    
    private float timer = 0;
    private float HandRightPrevZ;
    private float HandLeftPrevZ;
    private float timerPeriod = .3f;
    private Rigidbody rb;
    public float thrust;

	// Use this for initialization
	void Start () {
        StartFlying(GameController.launchHeight);
        rb = GetComponent<Rigidbody>();
        rb.mass = 10;
        thrust = 100;
        HandRightPrevZ = 999999999;
        HandLeftPrevZ = 999999999;
	}
	
	// Update is called once per frame
	void Update () {
        /*        
        timer += Time.deltaTime;       
        if (timer >= timerPeriod && KinectManager.instance.IsAvailable)
        {*/
            if ((HandRightPrevZ - KinectManager.instance.handRight.y > .05f)
                && (HandLeftPrevZ - KinectManager.instance.handLeft.y > .05f))
            {
                rb.AddForce(0, thrust, 0, ForceMode.Impulse);                
                timer = 0;
                Debug.Log("FLAP");
            }
        HandRightPrevZ = KinectManager.instance.handRight.y;
        HandLeftPrevZ = KinectManager.instance.handLeft.y;
        Debug.Log(HandRightPrevZ);
        //}
        /*      
        timer += Time.deltaTime;       
        if (timer >= timerPeriod)
        {
            if ((HandRightPrevZ - Input.mousePosition.y > .00001f))                
            {
                rb.AddForce(0, thrust, 0, ForceMode.Impulse);
                HandRightPrevZ = Input.mousePosition.y;                
                timer = 0;
                Debug.Log("FLAP");
            }
        //}*/
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

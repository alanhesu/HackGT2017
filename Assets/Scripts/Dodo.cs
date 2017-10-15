using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodo : MonoBehaviour {    
    private float timer = 0;
    private float HandRightPrevY;
    private float HandLeftPrevY;
    private float timerPeriod = .3f;
    private Rigidbody rb;

    public float thrust;
    private float deltaY = .05f;
    public float stamina;
    private float baseStam = 100;
    private float stamMult;
    private float flapCount = 0;
    public int agility;

	// Use this for initialization
	void Start () {        
        rb = GetComponent<Rigidbody>();
        rb.mass = 1;
        thrust = 2;
        stamina = baseStam;
        stamMult = .5f;
        agility = 30;
        HandRightPrevY = 999999999;
        HandLeftPrevY = 999999999;
        StartFlying(ref rb, GameController.launchHeight, GameController.startVel);
    }
	
	// Update is called once per frame
	void Update () {
        /*        
        timer += Time.deltaTime;       
        if (timer >= timerPeriod && KinectManager.instance.IsAvailable)
        {*/
        if (KinectManager.instance.IsAvailable)
        {
            if ((HandRightPrevY - KinectManager.instance.handRight.y > deltaY)
                && (HandLeftPrevY - KinectManager.instance.handLeft.y > deltaY))
            {
                if (stamina - Mathf.Sqrt(flapCount) * stamMult> 0)
                {
                    stamina -= Mathf.Sqrt(flapCount) * stamMult;
                }               
                rb.AddForce(0, thrust * stamina / baseStam, 0, ForceMode.Impulse);
                flapCount++;
                Debug.Log("" + thrust * stamina / baseStam + "    " + flapCount);
            }
            HandRightPrevY = KinectManager.instance.handRight.y;
            HandLeftPrevY = KinectManager.instance.handLeft.y;
            //Debug.Log(HandRightPrevY);

            if (Mathf.Abs(KinectManager.instance.leaningPosition) > .2)
            {
                rb.velocity = new Vector3(KinectManager.instance.leaningPosition * agility, rb.velocity.y, rb.velocity.z);
            }
            //Debug.Log("X  " + rb.position.x);
            //Quaternion rotTarget = Quaternion.Euler(0, 0, 45 * KinectManager.instance.leaningPosition);
            //rb.transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, .8f);
            rb.transform.eulerAngles = new Vector3(0, 0, -60 * KinectManager.instance.leaningPosition);
        }
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

    void StartFlying(ref Rigidbody rb, float startHeight, float startVel)
    {
        rb.transform.position = new Vector3(0, startHeight, 0);
        rb.velocity = new Vector3(0, 0, startVel);        
    }
}

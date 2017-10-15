using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : MonoBehaviour {
    private float timer = 0;
    private float flapTime = .2f;
    private float motorvel = 10000;
    HingeJoint hinge;
    JointMotor motor;
    private float angle = 10;
    public bool isRight;
    private Vector3 off;

    public GameObject body;

	// Use this for initialization
	void Start () {
        //Rigidbody rb = GetComponent<Rigidbody>();
        timer = .05f;
        /*
        rb.angularDrag = 0;
        rb.angularVelocity = new Vector3(9000, 0, 0);
        hinge = GetComponent<HingeJoint>();        
        motor = hinge.motor;
        hinge.motor = motor;
        hinge.useMotor = true;
        motor.force = 9999999999999999;
        */
        off = body.transform.position - transform.position;
        if (isRight)
        {
            angle = -1 * angle;
        }
        transform.parent = body.transform;
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= flapTime)
        {
            //motorvel = -1 * motorvel;
            angle = -1 * angle;
            timer = 0;
        }
        //motor.targetVelocity = motorvel;
        //motor.freeSpin = true;
        transform.RotateAround(body.transform.position, new Vector3(0, 0, 1), angle);
        //transform.position = transform.position + off;
    }
}

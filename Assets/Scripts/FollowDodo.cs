using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDodo : MonoBehaviour {
    private Vector3 offset;
    private GameObject dodo;
    private Vector3 oldPos;
    private Vector3 dodoPos;
    private float lockViewX;
    private float lockViewY;
    private float lockZ;

    void Start()
    {
        offset = transform.position;
        lockZ = offset.z;
    }

    void LateUpdate()
    {
        if (dodo == null)
        {
            dodo = GameObject.Find("Dodo(Clone)");
            oldPos = dodo.transform.position;           
        }
        else
        {
            dodoPos = dodo.transform.position;
            if (Mathf.Abs(oldPos.y - dodoPos.y) < 10)
            {              
                transform.position = offset + new Vector3(dodoPos.x, Vector3.Lerp(oldPos, dodoPos, .8f).y, dodoPos.z);
                lockViewY = Vector3.Lerp(oldPos, dodoPos, .8f).y - dodoPos.y;
            }
            else
            {
                transform.position = offset + dodoPos +  new Vector3(0, lockViewY, 0);
            }
            //Debug.Log((90 - Mathf.Abs(dodoPos.x) < 25) && (90 - Mathf.Abs(dodoPos.x) > 0));
            
            if (90 - Mathf.Abs(dodoPos.x) < 60)
            {
                float off = (dodoPos.x > 0) ? 30 : -30;
                Vector3 newPos = oldPos + new Vector3(off, 0, 0);
                transform.position = offset + new Vector3(lockViewX + Vector3.Lerp(newPos, dodoPos, .9f).x, dodoPos.y, dodoPos.z);
                lockViewX = Vector3.Lerp(newPos, dodoPos, .9f).x - dodoPos.x;
            }
            else
            {
                transform.position = offset + dodoPos + new Vector3(lockViewX, 0, 0);
            } 
            transform.position =  new Vector3(transform.position.x, transform.position.y, dodoPos.z + lockZ);                             
        }
        //Debug.Log(transform.position.x);
    }
}

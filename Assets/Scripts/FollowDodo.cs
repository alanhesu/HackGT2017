using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDodo : MonoBehaviour {
    private Vector3 offset;
    private GameObject dodo;
    private Vector3 oldPos;
    private Vector3 lockView;

    void Start()
    {
        offset = transform.position;
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
            if (Mathf.Abs(oldPos.y - dodo.transform.position.y) < 10)
            {               
                transform.position = offset + Vector3.Lerp(oldPos, dodo.transform.position, .8f);
                lockView = Vector3.Lerp(oldPos, dodo.transform.position, .8f) - dodo.transform.position;
            }
            else
            {
                transform.position = offset + lockView + dodo.transform.position;
            }        
        }
        //Debug.Log(transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanningManager : MonoBehaviour {

    public void fly (string scene)
    {
        Application.LoadLevel(scene);
        Debug.Log("Fly");
    }

    public void upgradeStamina ()
    {
        Debug.Log("Stamina");
    }

    public void upgradeThrust()
    {
        Debug.Log("Thrust");
    }

    public void upgradeStartHieght()
    {
        Debug.Log("Hieght");
    }
}

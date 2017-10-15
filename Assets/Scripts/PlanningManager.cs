using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanningManager : MonoBehaviour {
    public Text ThrustText;
    public Text HeightText;
    public Text StamText;
    public Text CashText;

    public void fly (string scene)
    {
        Application.LoadLevel(scene);
        //Debug.Log("Fly");
    }

    public void upgradeStamina ()
    {
        //Debug.Log("Stamina");
        GameController.upgradeStam();
    }

    public void upgradeThrust()
    {
        //Debug.Log("Thrust");
        GameController.upgradeThrust();
    }

    public void upgradeStartHieght()
    {
        //Debug.Log("Hieght");
        GameController.upgradeHeight();
    }

    void Update()
    {
        ThrustText.text = string.Format("[{0}] | Thrust: ${1}", GameController.numUpThrust, GameController.numUpThrust * 300);
        StamText.text = string.Format("[{0}] | Stamina: ${1}", GameController.numUpStam, GameController.numUpStam * 300);
        HeightText.text = string.Format("[{0}] | Height: ${1}", GameController.numUpHeight, GameController.numUpHeight * 300);
        CashText.text = string.Format("Cash: ${0:0.00}", GameController.cash);
    }
}

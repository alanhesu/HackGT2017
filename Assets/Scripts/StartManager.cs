using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour {

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
        Debug.Log("Planning");
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

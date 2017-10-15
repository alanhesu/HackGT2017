using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour {

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void quit()
    {
        Application.Quit();
    }
}

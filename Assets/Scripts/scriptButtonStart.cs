using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptButtonStart : MonoBehaviour {

    public Button buttonComponent;
    public Text label;
    public Image iconImage;


	// Use this for initialization
	void Start () {
        buttonComponent.onClick.AddListener(HandleClick);
        iconImage.color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
        label.text = "Start!";
	}

    void HandleClick()
    {
        iconImage.color = Color.green;
        GameController.state = GameController.State.Flying;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugScript : MonoBehaviour
{
    private Player player;
    private Controller controller;

    private Text text;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	    controller = GameObject.Find("Controller").GetComponent<Controller>();

	    text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    text.text = "";

        text.text += "canMove: " + (player.canMove ? "1" : "0") + "\n";
        
       
        text.text += "Move U: " + controller.moveU.ToString() + "\n";
	    text.text += "Move R: " + controller.moveR.ToString() + "\n";
	    text.text += "Move D: " + controller.moveD.ToString() + "\n";
	    text.text += "Move L: " + controller.moveL.ToString() + "\n";
    }
}

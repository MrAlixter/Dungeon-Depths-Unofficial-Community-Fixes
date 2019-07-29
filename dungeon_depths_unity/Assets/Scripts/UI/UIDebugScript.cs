using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugScript : MonoBehaviour
{
    private Player player;
    private Controller controller;

    private Text textObj;
    private string text { get { return textObj.text; } set { textObj.text = value; } }

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
	    controller = GameObject.Find("Controller").GetComponent<Controller>();

        textObj = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    text = "";

        text += "canMove: " + (player.canMove ? "1" : "0") + "\n";

        text += "moveHorAxis: " + Input.GetAxis("moveHorizontally") + "\n";
        text += "moveVerAxis: " + Input.GetAxis("moveVertically") + "\n";
        text += "Move U: " + controller.moveU.ToString() + "\n";
	    text += "Move R: " + controller.moveR.ToString() + "\n";
	    text += "Move D: " + controller.moveD.ToString() + "\n";
	    text += "Move L: " + controller.moveL.ToString() + "\n";
    }
}

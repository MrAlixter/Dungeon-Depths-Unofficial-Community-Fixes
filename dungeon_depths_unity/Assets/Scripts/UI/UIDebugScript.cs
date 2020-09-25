using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIDebugScript : MonoBehaviour
{
    private Player player;
    private PlayerInput input;

    private TextMeshProUGUI textObj;
    private string text { get { return textObj.text; } set { textObj.text = value; } }
    
	void Start () {
        player = Player.instance;
        //input = Controller.input;

        textObj = GetComponent<TextMeshProUGUI>();
	}
	
	void Update ()
	{
	    text = "";

        //text += "canMove: " + (player.can_move ? "1" : "0") + "\n";

        //text += $"Nav U: {input.actions.}\n";

        //   text += "moveHorAxis: " + Input.GetAxis("moveHorizontally") + "\n";
        //   text += "moveVerAxis: " + Input.GetAxis("moveVertically") + "\n";
        //   text += "Move U: " + controller.moveU.ToString() + "\n";
        //text += "Move R: " + controller.moveR.ToString() + "\n";
        //text += "Move D: " + controller.moveD.ToString() + "\n";
        //text += "Move L: " + controller.moveL.ToString() + "\n";
    }
}

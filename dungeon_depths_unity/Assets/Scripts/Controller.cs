using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Experimental.Playables;

public sealed class Controller : MonoBehaviour
{
    private static Controller _instance;
    public static Controller instance { get { return _instance != null ? _instance : new Controller(); } }

    public Controller()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    [Serializable]
    public struct Map
    {
        public bool down;
        public bool hold;
        public bool up;

        public void setFalse()
        {
            down = false;
            hold = false;
            up = false;
        }

        public void press()
        {
            if (hold)
            {
                down = false;
                up = false;
            }
            else
            {
                down = true;
                up = false;
            }
            hold = true;
        }

        public void release()
        {
            if (hold)
            {
                up = true;
            }
            else
            {
                up = false;
            }
            down = false;
            hold = false;
        }

        public override String ToString()
        {
            String ret = "";

            if (down) { ret += "1 "; }
            else { ret += "0 "; }

            if (hold) { ret += "1 "; }
            else { ret += "0 "; }

            if (up) { ret += "1"; }
            else { ret += "0"; }

            return ret;
        }
    }

    public List<Map> inputMaps;

    [SerializeField]
    public Map moveU;
    [SerializeField]
    public Map moveR;
    [SerializeField]
    public Map moveD;
    [SerializeField]
    public Map moveL;

    [SerializeField]
    public Map pause_menu;
    [SerializeField]
    public Map character_menu;

    void setAllFalse()
    {
        for(int i = 0; i < inputMaps.Count; i++)
        {
            inputMaps[i].setFalse();
        }
    }

    void setFalse(ref Map map)
    {
        map.down = false;
        map.hold = false;
        map.up = false;
    }

	// Use this for initialization
	void Start ()
	{
        inputMaps = new List<Map>();

	    moveU = new Map();
	    moveR = new Map();
	    moveD = new Map();
	    moveL = new Map();

        pause_menu = new Map();
        character_menu = new Map();

        inputMaps.Add(moveU);
	    inputMaps.Add(moveR);
	    inputMaps.Add(moveD);
	    inputMaps.Add(moveL);

        inputMaps.Add(pause_menu);
        inputMaps.Add(character_menu);

	    setAllFalse();
	}
	
	// Update is called once per frame
	void Update ()
	{
        moveU.release();
        moveR.release();
        moveD.release();
        moveL.release();

        if (Input.GetAxisRaw("moveVertically") > 0)
        {
            moveU.press();
            moveD.release();
        }
        else if (Input.GetAxisRaw("moveVertically") < 0)
        {
            moveU.release();
            moveD.press();
        }
        else
        {
            moveU.release();
            moveD.release();
        }

        if (Input.GetAxisRaw("moveHorizontally") > 0)
        {
            moveR.press();
            moveL.release();
        }
        else if (Input.GetAxisRaw("moveHorizontally") < 0)
        {
            moveR.release();
            moveL.press();
        }
        else
        {
            moveR.release();
            moveL.release();
        }

        if(Input.GetAxisRaw("Pause Menu") > 0)
            { pause_menu.press(); }
        else { pause_menu.release(); }

        if (Input.GetAxisRaw("Character Menu") > 0)
            { character_menu.press(); }
        else { character_menu.release(); }
    }
}

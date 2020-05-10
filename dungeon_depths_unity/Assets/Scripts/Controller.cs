using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Experimental.Playables;

public sealed class Controller : MonoBehaviour
{
    private static Controller _instance;
    public static Controller instance { get { if(_instance != null) { return _instance; } else { _instance = new Controller(); return _instance; } } }

    public Controller()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    [Serializable]
    public class Map
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
            if(hold)
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

    [Serializable]
    public class AnalogMap : Map
    {
        public float deadzone = 0.05f;
        public float magnitude;
        [SerializeField]
        private float raw;

        public new void setFalse()
        {
            base.setFalse();
            magnitude = 0;
        }

        public void update(float magnitude)
        {
            raw = magnitude;
            if(Mathf.Abs(magnitude) >= deadzone)
            {
                press();
                this.magnitude = magnitude;
            }
            else
            {
                release();
                this.magnitude = 0;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" {magnitude}";
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
    
    [SerializeField]
    public AnalogMap zoom;
    [SerializeField]
    public AnalogMap panHorizontally;
    [SerializeField]
    public AnalogMap panVertically;
    [SerializeField]
    public AnalogMap mouse_panHorizontally;
    [SerializeField]
    public AnalogMap mouse_panVertically;
    [SerializeField]
    private Vector2 mouse_position_on_down;
    [SerializeField]
    private Vector2 last_mouse_position;


    void setAllFalse()
    {
        for(int i = 0; i < inputMaps.Count; i++)
        {
            inputMaps[i].setFalse();
        }
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

        //mouse_zoom = new Map();
        //mouse_click = new Map();
        zoom = new AnalogMap();
        panHorizontally = new AnalogMap();
        panVertically = new AnalogMap();
        mouse_panHorizontally = new AnalogMap();
        mouse_panVertically = new AnalogMap();


        inputMaps.Add(moveU);
	    inputMaps.Add(moveR);
	    inputMaps.Add(moveD);
	    inputMaps.Add(moveL);

        inputMaps.Add(pause_menu);
        inputMaps.Add(character_menu);

        //inputMaps.Add(mouse_zoom);
        //inputMaps.Add(mouse_click);
        inputMaps.Add(zoom);
        inputMaps.Add(panHorizontally);
        inputMaps.Add(panVertically);
        inputMaps.Add(mouse_panHorizontally);
        inputMaps.Add(mouse_panVertically);


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

        //if(Input.GetAxisRaw("Zoom") > 0)
        //    { mouse_zoom.press(); }
        zoom.update(Input.GetAxis("Zoom"));
        panHorizontally.update(Input.GetAxis("PanHorizontally"));
        panVertically.update(-1*Input.GetAxis("PanVertically"));

        if(Input.GetMouseButtonDown(0))
        {
            mouse_panHorizontally.press();
            mouse_panVertically.press();
            mouse_position_on_down = Input.mousePosition;
            last_mouse_position = mouse_position_on_down;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            mouse_panHorizontally.release();
            mouse_panVertically.release();
        }
        if(Input.GetMouseButton(0))
        {
            float xDiff = Input.mousePosition.x - last_mouse_position.x;
            float yDiff = Input.mousePosition.y - last_mouse_position.y;

            xDiff /= Screen.width;
            yDiff /= Screen.width; //I don't know why it only works when both are divded by the width
            xDiff *= 85f; //I don't know why 85 happens to be the magic constant
            yDiff *= 85f;
            //Account for the aspect ratio
            float aspect_ratio = (16f / 9f) / ((float)Screen.width / (float)Screen.height);
            xDiff /= aspect_ratio;
            yDiff /= aspect_ratio;
            
            //You might be tempted to think that the fact that I'm multiplying and dividing by the same constants 
            //Means they're redundant but somehow that's not the case.
            //Short version, it works. I don't know why, but it's the most reliable way 
            
            mouse_panHorizontally.update(-1 * xDiff);
            mouse_panVertically.update(-1 * yDiff);
            last_mouse_position = Input.mousePosition;
        }
    }
}

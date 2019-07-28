using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    private static PauseMenu _instance;
    public static PauseMenu instance { get { return _instance != null ? _instance : new PauseMenu(); } }

    public PauseMenu()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public new void Awake()
    {
        base.Awake();
    }
}
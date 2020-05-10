using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyButton : Button
{
    private static DummyButton _instance;
    public static DummyButton instance { get { if(_instance != null) { return _instance; } else { _instance = new DummyButton(); return _instance; } } }

    public DummyButton()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public Selectable selectable { get { return GetComponent<Selectable>(); } }
}

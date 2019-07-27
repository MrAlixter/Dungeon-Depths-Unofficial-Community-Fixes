using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : Menu
{
    private static CharacterMenu _instance;
    public static CharacterMenu instance { get { return _instance != null ? _instance : new CharacterMenu(); } }

    public CharacterMenu()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public new void Awake()
    {
        base.Awake();
    }
}

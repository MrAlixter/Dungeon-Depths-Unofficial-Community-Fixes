using UnityEngine;
using UnityEditor;
using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
public class ConditionalHideAttribute : PropertyAttribute
{
    //The name of the bool field that will be in control
    public string ConditionalSourceField = "";
    //TRUE = Hide in inspector / FALSE = Disable in inspector 
    public bool HideInInspector = false;
    //Flips the hide/readonly condition
    public bool Inverted = false;

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector = false, bool inverted = false)
    {
        this.ConditionalSourceField = conditionalSourceField;
        this.HideInInspector = hideInInspector;
        this.Inverted = inverted;
    }
}
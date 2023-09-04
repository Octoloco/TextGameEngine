using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScriptableObject : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public bool isContainer;
    public bool isGrabable;

    [Header("Text for each action")]
    public string interactText;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Area", menuName = "ScriptableObjects/Area", order = 1)]
public class AreaScriptable : ScriptableObject
{
    public string areaName;
    public string longDescription;
    public string shortDescription;
    public bool visited = false;

    [Header("Connected Areas")]
    public AreaScriptable north;
    public AreaScriptable south;
    public AreaScriptable east;
    public AreaScriptable west;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    static public GameMaster Instance;

    [SerializeField] private AreaScriptable startArea;

    private AreaScriptable currentArea;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        EnterArea(startArea);
    }

    public void Move(int direction)
    {
        switch (direction)
        {
            case 0:
                EnterArea(currentArea.north);
                break;
            case 1:
                EnterArea(currentArea.south);
                break;
            case 2:
                EnterArea(currentArea.east);
                break;
            case 3:
                EnterArea(currentArea.west);
                break;
        }
    }

    private void EnterArea(AreaScriptable newArea)
    {
        if (newArea != null)
        {
            currentArea = newArea;
            if (!currentArea.visited)
            {
                currentArea.visited = true;
                TextWritter.Instance.WriteText(currentArea.longDescription + "\n");
            }
            else
            {
                TextWritter.Instance.WriteText(currentArea.shortDescription + "\n");
            }
        }
        else
        {
            TextWritter.Instance.WriteText("No path to that direction." + "\n");
        }
        AdjacentAreas();
    }

    private void AdjacentAreas()
    {
        if (currentArea.south != null)
        {
            TextWritter.Instance.WriteText(currentArea.south.areaName + " to the south." + "\n");
        }

        if (currentArea.north != null)
        {
            TextWritter.Instance.WriteText(currentArea.north.areaName + " to the north." + "\n");
        }

        if (currentArea.east != null)
        {
            TextWritter.Instance.WriteText(currentArea.east.areaName + " to the east." + "\n");
        }

        if (currentArea.west != null)
        {
            TextWritter.Instance.WriteText(currentArea.west.areaName + " to the west." + "\n");
        }
    }
}

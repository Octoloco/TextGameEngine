using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    static public GameMaster Instance;

    [SerializeField] private AreaScriptable startArea;
    [SerializeField] private GameObject subjectPrefab;
    [SerializeField] private GameObject subjectContentDrawer;

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

    public void ExecutePlayerAction(PlayerActions.actions action, string subjectName)
    {
        foreach (InteractableScriptableObject i in currentArea.items)
        {
            if (i.objectName == subjectName)
            {
                switch (action)
                {
                    case PlayerActions.actions.inspect:
                        TextWritter.Instance.WriteText(i.interactText + "\n");
                        break;
                    case PlayerActions.actions.grab:
                        if (i is ItemScriptableObject)
                        {
                            TextWritter.Instance.WriteText(i.objectName + " added to the inventory." + "\n");
                            SendToInventory(i as ItemScriptableObject);
                        }
                        break;
                }
            }
        }

        RemoveSubjects();
    }

    private void SendToInventory(ItemScriptableObject i)
    {
        currentArea.items.Remove(i);
        PlayerActions.Instance.AddToInventory(i);
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

    public void PopulateWorldSubjects()
    {
        float delay = 0;
        foreach (InteractableScriptableObject i in currentArea.items)
        {
            StartCoroutine(AddWorldSubject(delay, i));
            delay += .1f;
        }
    }

    private void RemoveSubjects()
    {
        float delay = 0;
        GameObject currentSubject;
        for (int i = subjectContentDrawer.transform.childCount - 1; i >= 0; i--)
        {
            currentSubject = subjectContentDrawer.transform.GetChild(i).gameObject;
            StartCoroutine(RemoveSubject(delay, currentSubject));
            delay += .1f;
        }
    }

    IEnumerator AddWorldSubject(float seconds, InteractableScriptableObject currentSubject)
    {
        yield return new WaitForSeconds(seconds);
        GameObject currentInstaceOfSubject;
        currentInstaceOfSubject = Instantiate(subjectPrefab, subjectContentDrawer.transform);
        currentInstaceOfSubject.GetComponent<PopulateSubject>().Populate(currentSubject.sprite, currentSubject.objectName);
        currentInstaceOfSubject.GetComponentInChildren<ButtonMultipleSprites>().onClick.AddListener(() => PlayerActions.Instance.SelectFromSubjectDrawer(currentSubject.objectName));
    }

    IEnumerator RemoveSubject(float seconds, GameObject currentSubject)
    {
        yield return new WaitForSeconds(seconds);
        currentSubject.GetComponent<Animator>().SetBool("Grow", false);
        Debug.Log(seconds);
        yield return new WaitForSeconds(.3f);
        Destroy(currentSubject);
    }
}

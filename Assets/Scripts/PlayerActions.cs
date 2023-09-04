using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    static public PlayerActions Instance;

    private actions selectedAction = actions.none;
    private List<ItemScriptableObject> items = new List<ItemScriptableObject>();

    public enum actions
    {
        none,
        inspect,
        grab,
    }

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

    public void AddToInventory(ItemScriptableObject item)
    {
        items.Add(item);
    }

    public void Move(int direction)
    {
        GameMaster.Instance.Move(direction);
    }

    public void Inspect()
    {
        selectedAction = actions.inspect;
        GameMaster.Instance.PopulateWorldSubjects();
    }

    public void SelectFromSubjectDrawer(string objectName)
    {
        GameMaster.Instance.ExecutePlayerAction(selectedAction, objectName);
    }
}

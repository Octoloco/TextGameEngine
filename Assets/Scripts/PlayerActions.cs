using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private actions selectedAction = actions.none;

    enum actions
    {
        none,
        move,
    }

    public void Move(int direction)
    {
        GameMaster.Instance.Move(direction);
    }
}

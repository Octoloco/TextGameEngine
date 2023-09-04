using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GUITooltip : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("inside");
        PlayerTooltip.Instance.SetTooltip(transform.GetComponentInParent<PopulateSubject>().GetName());
        PlayerTooltip.Instance.ShowTooltip();
    }
}

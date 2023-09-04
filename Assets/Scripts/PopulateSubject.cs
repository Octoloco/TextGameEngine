using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateSubject : MonoBehaviour
{
    [SerializeField] private Image subjectSprite;
    [SerializeField] private string objectName;

    public void ShowTooltip()
    {
        PlayerTooltip.Instance.SetTooltip(transform.GetComponentInParent<PopulateSubject>().GetName());
        PlayerTooltip.Instance.ShowTooltip();
    }

    public void HideTooltip()
    {
        PlayerTooltip.Instance.HideTooltip();
    }

    public void Populate(Sprite newSprite, string newName)
    {
        subjectSprite.sprite = newSprite;
        objectName = newName;
    }

    public string GetName()
    {
        return objectName;
    }
}

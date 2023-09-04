using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class PlayerTooltip : MonoBehaviour
{
    static public PlayerTooltip Instance;

    [SerializeField] private TMP_Text tooltipText;

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

    private void Start()
    {
        HideTooltip();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Input.mousePosition.x + 22, Input.mousePosition.y);
    }

    public void SetTooltip(string tooltip)
    {
        tooltipText.text = tooltip;
    }

    public void ShowTooltip()
    {
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}

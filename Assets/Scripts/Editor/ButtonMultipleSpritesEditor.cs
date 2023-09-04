using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(ButtonMultipleSprites))]
public class ButtonMultipleSpritesEditor : ButtonEditor
{
    private SerializedProperty targetList;

    protected override void OnEnable()
    {
        base.OnEnable();
        targetList = serializedObject.FindProperty("m_TargetGraphics");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(targetList);

        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}

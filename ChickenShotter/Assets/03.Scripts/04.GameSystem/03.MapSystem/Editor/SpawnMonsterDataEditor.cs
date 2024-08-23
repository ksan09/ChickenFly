using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpawnMonsterData))]
public class SpawnMonsterDataEditor : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var poolObjectRect = new Rect(position.x, position.y, 160, position.height);
        var countRect = new Rect(position.x + 165, position.y, 40, position.height);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(poolObjectRect, property.FindPropertyRelative("Monster"), GUIContent.none);
        EditorGUI.PropertyField(countRect, property.FindPropertyRelative("Count"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();



    }


}

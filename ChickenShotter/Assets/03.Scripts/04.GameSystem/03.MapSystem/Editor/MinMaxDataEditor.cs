using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MinMaxData<int>))]
public class MinMaxDataEditor : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        float oneHeight = position.height;

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var minObjectRect = new Rect(position.x, position.y, 30, oneHeight);
        var maxObjectRect = new Rect(position.x + 35, position.y, 30, oneHeight);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(minObjectRect, property.FindPropertyRelative("Min"), GUIContent.none);
        EditorGUI.PropertyField(maxObjectRect, property.FindPropertyRelative("Max"), GUIContent.none);


        if (property.FindPropertyRelative("Min").intValue > property.FindPropertyRelative("Max").intValue)
            property.FindPropertyRelative("Max").intValue = property.FindPropertyRelative("Min").intValue;

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;


        EditorGUI.EndProperty();



    }


}

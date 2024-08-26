using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SpawnMonsterData))]
public class SpawnMonsterDataEditor : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        float oneHeight = position.height;

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var poolObjectRect = new Rect(position.x, position.y, 80, oneHeight);
        
        var countRect1 = new Rect(position.x + 85, position.y, 20, oneHeight);
        var countRect2 = new Rect(position.x + 85 + 25, position.y, 20, oneHeight);
        var countRect3 = new Rect(position.x + 85 + 50, position.y, 30, oneHeight);

        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(poolObjectRect, property.FindPropertyRelative("Monster"), GUIContent.none);
        EditorGUI.PropertyField(countRect1, property.FindPropertyRelative("SpawnStart"), GUIContent.none);
        EditorGUI.PropertyField(countRect2, property.FindPropertyRelative("SpawnEnd"), GUIContent.none);
        EditorGUI.PropertyField(countRect3, property.FindPropertyRelative("Weight"), GUIContent.none);

        int start = property.FindPropertyRelative("SpawnStart").intValue * 10;
        int end = (property.FindPropertyRelative("SpawnEnd").intValue + 1) * 10;
        var backRect = new Rect(position.x + 170, position.y + 1, 100, oneHeight - 2);
        EditorGUI.DrawRect(backRect, Color.black);

        if (property.FindPropertyRelative("SpawnStart").intValue < 0)
            property.FindPropertyRelative("SpawnStart").intValue = 0;

        if (property.FindPropertyRelative("SpawnEnd").intValue > 9)
            property.FindPropertyRelative("SpawnEnd").intValue = 9;

        for(int i = 0; i < 100; i += 10)
        {

            Color feelColor = Color.yellow;
            if (i < start || end <= i)
                feelColor = new Color(0.2f, 0.2f, 0.2f);
            else if (i % 20 == 0)
                feelColor = Color.green;

            var feelRect = new Rect(position.x + 170 + i + 1, position.y + 2, 8, oneHeight - 4);
            EditorGUI.DrawRect(feelRect, feelColor);


        }
        


        // Set indent back to what it was
        EditorGUI.indentLevel = indent;
        

        EditorGUI.EndProperty();



    }


}

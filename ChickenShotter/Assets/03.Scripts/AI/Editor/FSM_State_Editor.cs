using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FSM_State))]
[CanEditMultipleObjects]
public class FSM_State_Editor : Editor
{

    FSM_State _state;
    GUIStyle _labelStyle;

    private void OnEnable()
    {
        _state = (FSM_State)target;
    }

    public override void OnInspectorGUI()
    {
        _labelStyle = new GUIStyle(GUI.skin.label);
        _labelStyle.richText = true;
        base.OnInspectorGUI();

        if (_state == null)
            return;

        ResetButton();





    }

    private void ResetButton()
    {

        if(GUILayout.Button("Reset", GUILayout.Width(200)))
        {

            _state.Transitions.Clear();

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PanelState
{
    start,
    shop,
    setting,
    sounds
}
public class CrtPanel : MonoBehaviour
{
    private PanelState state = PanelState.start;
    public PanelState State { get { return state; } set { state = value;  } }
}

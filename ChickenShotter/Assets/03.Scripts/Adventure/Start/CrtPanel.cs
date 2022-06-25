using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PanelState
{
    not,
    start,
    shop,
    setting,
    sounds,
    skill
}
public class CrtPanel : MonoBehaviour
{
    private PanelState state = PanelState.start;
    public PanelState State { get { return state; } set { state = value;  } }

    public void PanelChanging(PanelState changeState)
    {
        state = PanelState.not;
        StartCoroutine(PanelChangeDelay(changeState));
    }
    IEnumerator PanelChangeDelay(PanelState changeState)
    {
        yield return new WaitForSeconds(1f);
        state = changeState;

    }

}

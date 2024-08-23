using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngameButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public event Action OnIB_PointerDownEvent;
    public event Action OnIB_PointerUpEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnIB_PointerDownEvent?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnIB_PointerUpEvent?.Invoke();
    }

}

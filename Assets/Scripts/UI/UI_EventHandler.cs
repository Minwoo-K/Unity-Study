using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public Action<PointerEventData> DragHandler = null;
    public Action<PointerEventData> ClickHandler = null;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (DragHandler != null)
            DragHandler.Invoke(eventData);
        //Vector2 positionChange = eventData.position - InitialPosition;
        //transform.position = InitialPosition + positionChange;
        //EndPosition = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnClick");
        if (ClickHandler != null)
            ClickHandler.Invoke(eventData);
    }
}

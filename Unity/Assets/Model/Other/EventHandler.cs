using System;
using ETModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
{
    public BridgeEvent<PointerEventData> OnPointerDownAction= new BridgeEvent<PointerEventData>();
    public BridgeEvent<PointerEventData> OnPointerUpAction= new BridgeEvent<PointerEventData>();
    public BridgeEvent<PointerEventData> OnBeginDragAction= new BridgeEvent<PointerEventData>();
    public BridgeEvent<PointerEventData> OnDragAction= new BridgeEvent<PointerEventData>();
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownAction?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerUpAction?.Invoke(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragAction?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragAction?.Invoke(eventData);
    }
}

public class BridgeEvent<T>: UnityEvent<T>
{
    
}
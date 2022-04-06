using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldCoordinator : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Tap(eventData.pointerCurrentRaycast.worldPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Tap(eventData.pointerCurrentRaycast.worldPosition);
    }

    public void Tap(Vector3 coordinate)
    {
        GameServices.instance.coordinateController.SetLastCoordinate(coordinate);
    }
}

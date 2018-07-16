using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckDropHandler : MonoBehaviour, IDropHandler {

    public DragHandler.Slot typeOfItem;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called on " + gameObject.name);
        //RectTransform dropZone = transform as RectTransform;
        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d != null)
        {
            if ( typeOfItem == d.typeOfItem )
            {
                Debug.Log("Parent to return to changed to" + this.name);
                d.parentToReturnTo = this.transform;
                
            }
            else
            {
                Debug.Log("Type of item does not match!");
            }
        }

    }
}

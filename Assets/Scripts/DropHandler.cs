using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public bool selective = true;
    public GameMaster gameMaster;

    public DragHandler.Slot typeOfItem;
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d != null)
        {
            if (selective)
            {
                if (typeOfItem == d.typeOfItem)
                {
                    d.placeHolderParent = this.transform;
                    // **** TODO DO THIS INSIDE GAME MASTER CLASS (somehow)
                    if (gameMaster.dropZoneChildCount != 0)
                    {
                        gameMaster.dropZoneChildCount--;
                    }
                    // *****
                }
                else
                {
                    Debug.Log("Type of item does not match!");
                }
            }
            else
            {
                d.placeHolderParent = this.transform;
                // **** TODO DO THIS INSIDE GAME MASTER CLASS (somehow)
                if (gameMaster.dropZoneChildCount != 0)
                {
                    gameMaster.dropZoneChildCount--;
                }
                // *****

            }

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d != null && d.placeHolderParent == this.transform)
        {
            d.placeHolderParent = d.parentToReturnTo;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called on " + gameObject.name);
        //RectTransform dropZone = transform as RectTransform;
            DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
            if (d != null)
            {
                if (selective)
                {
                    if (typeOfItem == d.typeOfItem)
                    {
                        Debug.Log("Parent to return to changed to" + this.name);
                        d.parentToReturnTo = this.transform;
                        // **** TODO DO THIS INSIDE GAME MASTER CLASS (somehow)
                        if (gameMaster.dropZoneChildCount != 0)
                        {
                            gameMaster.dropZoneChildCount--;
                        }
                        // *****
                    }
                    else
                    {
                        Debug.Log("Type of item does not match!");
                    }
                }
                else
                {
                    Debug.Log("Parent to return to changed to" + this.name);
                    d.parentToReturnTo = this.transform;
                    // **** TODO DO THIS INSIDE GAME MASTER CLASS (somehow)
                    if (gameMaster.dropZoneChildCount != 0)
                    {
                        gameMaster.dropZoneChildCount--;
                    }
                    // *****

                }

            }

    }

}

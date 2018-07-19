using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler{

    private Image image;
    public Transform parentToReturnTo;
    //public Transform placeHolderParent = null;
    //GameObject placeholder = null;
    private Transform thisTransRef;

    public enum Slot{ MAGAZINE, DRINK, CANDY, CHIPS, CHOCOLATE, TV, RADIO };
    public Slot typeOfItem;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        thisTransRef = transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("ITEM: OnBeginDrag");
        //placeholder = new GameObject();
        //placeholder.transform.SetParent(this.transform.parent);
        //LayoutElement le = placeholder.AddComponent<LayoutElement>();
      //  le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
       // le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
       // le.flexibleWidth = 0;
       // le.flexibleHeight = 0;

       // placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex() );

        parentToReturnTo = this.transform.parent;
       // placeHolderParent = parentToReturnTo;

        image.color = Color.green;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.transform.SetParent(this.transform.parent.parent);
        //Debug.Log("My parent is: " + transform.parent.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ITEM: OnDrag");
        //        transform.position = Camera.main.ScreenToWorldPoint(pos);
        transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

       // var world_point_mousePos = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Mathf.Abs(Camera.main.transform.position.z)));
        //thisTransRef.position = world_point_mousePos;

        //  if (placeholder.transform.parent != placeHolderParent)
        //       placeholder.transform.SetParent(placeHolderParent);

        //   int newSiblingIndex = placeHolderParent.childCount;

        //  for (int i = 0; i < placeHolderParent.childCount; i++)
        //   {
        //     if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
        //       {
        //           newSiblingIndex = i;
        //      if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
        //          {
        //              newSiblingIndex--;
        //         }
        //         break;
        //        }
        //    }

        //    placeholder.transform.SetSiblingIndex(newSiblingIndex);
        //Debug.Log( Camera.main.ScreenToWorldPoint(eventData.position) );
        //        transform.position = Camera.main.WorldToScreenPoint(pos);
        //        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ITEM: OnEndDrag");

        image.color = Color.white;
        this.transform.SetParent(parentToReturnTo);
        //this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //transform.localPosition = Vector3.zero;

        //Destroy(placeholder);
    }

}

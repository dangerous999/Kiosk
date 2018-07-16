using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IDropHandler
{

    public GameObject[] objects;
    public GameObject objectToStore;
    private GameObject instance;
    bool changedParent = false;
    public int count = 10;
    public Text counterText;
    public Transform parentToReturnTo;

    public enum Slot { OBJECT1, OBJECT2, OBJECT3, OBJECT4, OBJECT5, TV, RADIO };
    public DragHandler.Slot typeOfItem;

    void Awake()
    {
        objects = new GameObject[count];
    }
    void Start()
    {
        counterText = GetComponentInChildren<Text>();
        for (int i = 0; i < count; i++)
        {
            objects[i] = objectToStore;
        }
    }
    void Update()
    {
        counterText.text = "x" + count.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform;

        instance = Instantiate(objectToStore, this.transform.parent);
        instance.GetComponent<CanvasGroup>().blocksRaycasts = false;

        count--;
        //objects.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //objects.transform.SetParent(this.transform);
//        this.transform.SetParent(this.transform.parent.parent);
//        Debug.Log("My parent is: " + transform.parent.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //        transform.position = Camera.main.ScreenToWorldPoint(pos);
        instance.transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        instance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //Debug.Log(Camera.main.ScreenToWorldPoint(eventData.position));
        //        transform.position = Camera.main.WorldToScreenPoint(pos);
        //        transform.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //count--;
        //eventData.pointerDrag.transform.SetParent(parentToReturnTo);
        instance.transform.SetParent(parentToReturnTo);
        instance.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //objects.transform.SetParent(parentToReturnTo);
        //objects.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //transform.localPosition = Vector3.zero;
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called on " + gameObject.name);
        //RectTransform dropZone = transform as RectTransform;
        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d != null)
        {
            if ( typeOfItem == d.typeOfItem  )
            {
                Destroy(instance);
                count++;
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

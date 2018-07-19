using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{

    public GameObject[] objects;
    public GameObject objectToStore;
    private GameObject instance;
    bool changedParent = false;
    public int count = 10;
    private int broj = 0;
    public Text counterText;

    ////
    public GameObject childPrefab, instantiatedChild;
    private Child childScript;
    private DragHandler dragHandlerScript;
    ////
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

    public void OnPointerDown(PointerEventData eventData)
    {   
            if (this.transform.childCount <= 2)
            {
                GameObject go = Instantiate(childPrefab, transform, true) as GameObject;
                instantiatedChild = go;
                broj++;
            }
        
        

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("DECK: OnBeginDrag");
        ////
        if (instantiatedChild != null)
        {
            dragHandlerScript = instantiatedChild.GetComponent<DragHandler>();        
        }
        ////


        //instance = Instantiate(objectToStore, parentToReturnTo);
        //instance.transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        //instance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);        
        //instance.GetComponent<CanvasGroup>().blocksRaycasts = true;

        count--;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DECK: On drag");
        ////
        if (instantiatedChild != null)
        {
            dragHandlerScript.OnDrag(eventData);
        }
        ////
        //        transform.position = Camera.main.ScreenToWorldPoint(pos);
        ////instance.transform.position = Camera.main.ScreenToWorldPoint(eventData.position);
        ////instance.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //Debug.Log(Camera.main.ScreenToWorldPoint(eventData.position));
        //        transform.position = Camera.main.WorldToScreenPoint(pos);
        //        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("DECK: OnEndDrag");

        dragHandlerScript.OnEndDrag(eventData);

        instantiatedChild = null;
        dragHandlerScript = null;
        //count--;
        //eventData.pointerDrag.transform.SetParent(parentToReturnTo);
        ////instance.transform.SetParent(parentToReturnTo);
        //////instance.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //objects.transform.SetParent(parentToReturnTo);
        //objects.GetComponent<CanvasGroup>().blocksRaycasts = true;
        //transform.localPosition = Vector3.zero;
    }
   

}

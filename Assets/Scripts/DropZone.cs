using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{

    public Transform itemZone;
    public Transform requestZone;
    public Character character;
    ////    public GameObject[] itemsInRequestZone;
    public DragHandler.Slot[] itemsInRequestZone;
////    public GameObject[] itemsInDropZone;
    public DragHandler.Slot[] itemsInDropZone;
    public GameMaster gameMaster;

    private int childCount;

	// Use this for initialization
	void Start () {
        /*
        for(int i = 0; i < itemsInRequestZone.Length; i++)
        {
            itemsInRequestZone[i] = character.items[i].GetComponent<DragHandler>().typeOfItem;
        }
        ////itemsInRequestZone = character.items;
        ////itemsInDropZone = new GameObject[transform.childCount];
        itemsInDropZone = new DragHandler.Slot[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            ////itemsInDropZone[i] = transform.GetChild(i).gameObject;
            itemsInDropZone[i] = transform.GetChild(i).gameObject.GetComponent<DragHandler>().typeOfItem;
        }*/
    }
	
	// Update is called once per frame
	void Update () {

    }

 
    public void OnDrop(PointerEventData eventData)
    {
        gameMaster.dropZoneChildCount = transform.childCount;// + 1;
        ////itemsInDropZone = new GameObject[transform.childCount];
//        gameMaster.itemsInDropZone = new DragHandler.Slot[transform.childCount];
        gameMaster.itemsInDropZone = new GameObject[transform.childCount];


        for (int i = 0; i < transform.childCount; i++)
        {
            ////itemsInDropZone[i] = transform.GetChild(i).gameObject;
            gameMaster.itemsInDropZone[i] = transform.GetChild(i).gameObject; //.GetComponent<DragHandler>().typeOfItem;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance = null;

    public int dropZoneChildCount;
    public int requestZoneChildCount;

    public DropZone dropZone;
    public Transform requestZone;
    public Character character;

    //public DragHandler.Slot[] itemsInRequestZone;
    //public DragHandler.Slot[] itemsInDropZone;
    public GameObject[] itemsInRequestZone;
    public GameObject[] itemsInDropZone;

    private int highscore;
    private double yourHappiness;
    private int communityHappiness;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Use this for initialization
    void Start () {
        requestZoneChildCount = character.items.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("dropZoneChildCount: " + dropZoneChildCount);
            Debug.Log("requestZoneChildCount: " + requestZoneChildCount);
            ////itemsInDropZone = new GameObject[transform.childCount];

            //            itemsInDropZone = new DragHandler.Slot[dropZoneChildCount];
            //            itemsInRequestZone = new DragHandler.Slot[requestZoneChildCount];
            dropZoneChildCount = dropZone.GetComponent<Transform>().childCount;
            itemsInDropZone = new GameObject[dropZoneChildCount];
            itemsInRequestZone = new GameObject[requestZoneChildCount];

            for (int i = 0; i < requestZoneChildCount; i++)
            {
                itemsInRequestZone[i] = character.items[i]; //.GetComponent<DragHandler>().typeOfItem;
            }
            for (int i = 0; i < dropZoneChildCount; i++)
            {
                ////itemsInDropZone[i] = transform.GetChild(i).gameObject;
                itemsInDropZone[i] = dropZone.transform.GetChild(i).gameObject; //.GetComponent<DragHandler>().typeOfItem;
            }
            CheckItems();
        }
        if (Input.GetKey(KeyCode.R))
        {
            RemoveItemsFromRequestZone();
        }
    }

    public void CheckItems()
    {
        Debug.Log("Check items");
        Debug.Log("Items in requestzone length: " + itemsInRequestZone.Length);
        ////List<GameObject> A = new List<GameObject>( new GameObject[itemsInDropZone.Length] );
        List<DragHandler.Slot> A = new List<DragHandler.Slot>(new DragHandler.Slot[itemsInDropZone.Length]);

        ////List<GameObject> B = new List<GameObject>( new GameObject[itemsInRequestZone.Length] );
        List<DragHandler.Slot> B = new List<DragHandler.Slot>(new DragHandler.Slot[itemsInRequestZone.Length]);
        Debug.Log(itemsInDropZone.Length);
        for (int i = 0; i < itemsInDropZone.Length; i++)
        {
            //Debug.Log( "i: " + i );
            A[i] = itemsInDropZone[i].GetComponent<DragHandler>().typeOfItem;
        }
        for (int j = 0; j < itemsInRequestZone.Length; j++)
        {
            B[j] = itemsInRequestZone[j].GetComponent<DragHandler>().typeOfItem;
        }

        for (int i = 0; i < itemsInDropZone.Length; i++)
        {
            Debug.Log("A" + i + ": " + itemsInDropZone[i]);
        }
        for (int j = 0; j < itemsInRequestZone.Length; j++)
        {
            Debug.Log("B" + j + ": " + itemsInRequestZone[j]);
        }


        if (CompareLists(A, B))
        {
            Debug.Log("Items are the same.");
            character.satisfied = true; ;
        }
    }
    public static bool CompareLists<T>(List<T> aListA, List<T> aListB)
    {
        if (aListA == null || aListB == null || aListA.Count != aListB.Count)
            return false;
        if (aListA.Count == 0)
            return true;
        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count))
            {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }-+
        for (int i = 0; i < aListB.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count))
            {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
        return lookUp.Count == 0;
    }
    /// <summary>
    /// Receives items that the character wants and puts them into the request bubble
    /// </summary>
    /// <param name="numberOfItems"></param>
    /// <param name="items"></param>
    public void RecvItemsFromCharacter(int numberOfItems, GameObject[] items)
    {
        requestZoneChildCount = numberOfItems;
//        itemsInRequestZone = new DragHandler.Slot[requestZoneChildCount];
        itemsInRequestZone = new GameObject[requestZoneChildCount];
        for (int i = 0; i < requestZoneChildCount; i++)
        {
            itemsInRequestZone[i] = Instantiate( items[i] ); //.GetComponent<DragHandler>().typeOfItem;        }
        }
        for (int i = 0; i < items.Length; i++)
        {
            itemsInRequestZone[i].transform.SetParent(requestZone);
//            itemsInRequestZone[i].transform.localScale = new Vector3(1, 1, 1);
            itemsInRequestZone[i].transform.localScale = new Vector3(0.5f, 0.5f, 1);
            //Instantiate( items[i], requestZone );
        }

    }
    public void RemoveItemsFromRequestZone()
    {
        for (int i = 0; i < requestZoneChildCount; i++)
        {
            Destroy( itemsInRequestZone[i] );
        }
    }



}

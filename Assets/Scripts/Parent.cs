using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Parent : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler {

    public GameObject childPrefab, instantiatedChild;

    private Child childScript;

	// Use this for initialization
	void Start () {
        //childPrefab = Resources.Load("ChipsChild") as GameObject;
	}

    public void OnPointerDown(PointerEventData data)
    {
        print("mouse down");
        StartCoroutine("Instantiator");
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (instantiatedChild != null)
        {
            childScript = instantiatedChild.GetComponent<Child>();
        }
    }
    public void OnDrag(PointerEventData data)
    {
        if (instantiatedChild != null)
        {
            childScript.OnDrag(data);
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        instantiatedChild = null;
        childScript = null;
    }

    IEnumerator Instantiator()
    {
        yield return new WaitForSeconds(0);
        GameObject go = Instantiate(childPrefab, transform.parent, false) as GameObject;
        instantiatedChild = go;
    }
}

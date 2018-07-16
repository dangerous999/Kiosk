using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour {

    private Text childCounterText;
    private int childCount;
    void Awake()
    {
        childCounterText = GetComponentInChildren<Text>();
    }

	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        childCount = transform.childCount - 1; // To ignore text as a child and only count objects
        if (childCount == 0)
        {
            childCounterText.text = "";
        }
        else
        {
            childCounterText.text = "x" + (transform.childCount - 1).ToString();
        }

    }
}

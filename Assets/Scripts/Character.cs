using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public double speed;
    public double timeToWait;
    public float timer;
    public Transform startPosition;
    public Transform buyingPosition;
    public Transform endPosition;
    public Transform requestZone;

    public GameObject[] items;
    public GameMaster gameMaster;


    public bool satisfied = false;
    public bool timerStop = false;
	// Use this for initialization
	void Start () {

        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
	
	// Update is called once per frame
	void Update () {
		if (timer >= 3.5 && !timerStop)
        {
            IWantItems();
            timer = 0;
            timerStop = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            IWantItems();
        }
	}
    void FixedUpdate()
    {
        if (!timerStop)
            timer += Time.deltaTime;
    }
    /// <summary>
    /// Sends items to GameMaster
    /// </summary>
    public void IWantItems()
    {
        gameMaster.RecvItemsFromCharacter(items.Length, items);      
    }
    public void GotItems()
    {
        //TO DO update happiness based on items got and/or not got
    }
    public void ChangeCommunityHappiness()
    {
        // TO DO change happiness based on satisfied
    }
    public void Come()
    {
        // TO DO move from startPosition to buyingPosition
    }
    public void Leave()
    {
        // TO DO move from buyingPosition to endPosition
    }

}

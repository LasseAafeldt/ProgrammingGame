﻿using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {
    public static int ActiveID;
    // Use this for initialization
    void Start () {
        ActiveID = 0;
        //RunQueue.InitializeQueue();
        //Debug.Log("RunQueueSize: " + RunQueue.GetSize());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void runQueue()
    {
        Debug.Log("Running program...");
        RunQueue.run();
        //QueueTest.test();
    }

    public void Hint()
    {
        ConsoleUI.ResetText();
        ConsoleUI.AddText(room1AccessPanelAssignement.hints.GetNextHint());
    }
    public static void ResetID()
    {
        ActiveID = 0;
    }
}

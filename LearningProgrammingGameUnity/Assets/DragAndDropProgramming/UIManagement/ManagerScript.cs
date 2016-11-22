using UnityEngine;
using System;
using System.Collections;

public class ManagerScript : MonoBehaviour {
    public static int ActiveID;
    public static bool[] ConstructionModulesCollected = new bool[5];
    public static bool[] ConstructionModulesHandedIn = new bool[5];
    //this for initialization
    void Start () {
        ActiveID = 0;
        //Debug.Log("RunQueueSize: " + RunQueue.GetSize());
        for(int i = 0; i < 5; i++)
        {
            ConstructionModulesCollected[i] = false;
            ConstructionModulesHandedIn[i] = false;
        }
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

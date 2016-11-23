using UnityEngine;
using System;
using System.Collections;

public class ManagerScript : MonoBehaviour {
    private static int ActiveID;
    public static bool[] ConstructionModulesCollected = new bool[5];
    public static bool[] ConstructionModulesHandedIn = new bool[5];
    public static bool CanMove = true;
    //this for initialization

    public static int GetActiveID()
    {
        return ActiveID;
    }
    public static void SetActiveID(int newID)
    {
        ActiveID = newID;
    }
    public static bool IsAllHandedIn()
    {
        for(int i = 0; i < ConstructionModulesHandedIn.Length; i++)
        {
            if(ConstructionModulesHandedIn[i] == false)
            {
                return false;
            }
        }
        return true;
    }
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

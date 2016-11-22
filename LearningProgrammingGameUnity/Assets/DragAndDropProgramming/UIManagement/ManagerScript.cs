using UnityEngine;
using System;
using System.Collections;

public class ManagerScript : MonoBehaviour {
    private static int ActiveID;

	public static int GetActiveID(){
		return ActiveID;
	}
	public static void SetActiveID(int newId){
		Debug.Log (newId);
		ActiveID = newId;
	}
    //this for initialization
    void Start () {
        ActiveID = 0;
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

using UnityEngine;
using System.Collections;

public class ManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        RunQueue.InitializeQueue();
        Debug.Log("RunQueueSize: " + RunQueue.GetSize());
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
}

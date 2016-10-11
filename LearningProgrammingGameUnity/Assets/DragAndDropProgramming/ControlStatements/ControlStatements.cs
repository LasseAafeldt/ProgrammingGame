using UnityEngine;
using System.Collections;

public abstract class ControlStatements {
    public void AddToQueue()
    {
        RunQueue queueRunning = new RunQueue();
        queueRunning.AddToQueue(this);
    }
    public void RemoveFromQueue()
    {
        RunQueue queueRunning = new RunQueue();
        queueRunning.RemoveFromQueue(this);
    }
    public abstract string GetType();
    public abstract void RunThis();
}

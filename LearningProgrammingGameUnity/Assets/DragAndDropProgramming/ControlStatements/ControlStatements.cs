using UnityEngine;
using System.Collections;

public abstract class ControlStatements : MonoBehaviour {
    public void AddToQueue(ControlStatements statement)
    {
        RunQueue queueRunning = new RunQueue();
        queueRunning.AddToQueue(statement);
    }
    public void RemoveFromQueue(ControlStatements statement)
    {
        RunQueue queueRunning = new RunQueue();
        queueRunning.RemoveFromQueue(statement);
    }
    public abstract string GetType();
    public abstract void RunThis();
}

using UnityEngine;
using System.Collections;


public abstract class ControlStatements {
    public void AddToQueue(int position)
    {
        RunQueue.AddToQueue(this, position);
    }
    public void RemoveFromQueue(int position)
    {
        RunQueue.RemoveFromQueue(position);
    }
    public abstract string GetControlType();
    public abstract void RunThis();
}


using UnityEngine;
using System.Collections;

public class RunQueue : MonoBehaviour {
    private static ArrayList theRunQueue = new ArrayList();
    private static int i = 0;
    public void AddToQueue(ControlStatements statement)
    {
        theRunQueue.Add(statement);
    }
    public void RemoveFromQueue(ControlStatements statement)
    {
        theRunQueue.Remove(statement);
    }

    public static ControlStatements Next()
    {

        if (theRunQueue.Count <= 0)
            return null;
        else
        {
            return (ControlStatements)theRunQueue[i+1];
        }
    }
}

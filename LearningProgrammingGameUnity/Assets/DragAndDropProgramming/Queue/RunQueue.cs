
using UnityEngine;
using System.Collections;

public class RunQueue {
    private static ArrayList runQueue = new ArrayList();
    private static int iterator = 0;
    /*public static void AddToQueue(ControlStatements statement)
    {
        runQueue.Add(statement);
    }*/
    public static int GetSize()
    {
        return runQueue.Count;
    }
    public static void InitializeQueue()
    {
        for (int i = 0; i < GameObject.Find("DropPanel").transform.childCount; i++)
        {
            runQueue.Add(null);
        }
    }
    public static void AddToQueue(ControlStatements statement, int position)
    {
        //Debug.Log("trying to add " + statement.GetControlType() + " at position " + position + "...");
        if (RunQueue.GetAt(position) != null)
        {
            //Debug.Log("there was an object there already! " + RunQueue.GetAt(position).GetControlType());
            runQueue.RemoveAt(position);
            runQueue.Insert(position, statement);
        }
        else
        {
            //Debug.Log("There was nothing here ");
            runQueue.Add(statement);
        }
    }
    public static void RemoveFromQueue(ControlStatements statement)
    {
        runQueue.Remove(statement);
    }
    public static void RemoveFromQueue(int position)
    {
        runQueue[position] = null;
        /*runQueue.RemoveAt(position);
        runQueue.Insert(position,null);*/
    }
    public static int GetCurrentI()
    {
        return iterator;
    }
    public static ControlStatements GetAt(int i)
    {
        return (ControlStatements)runQueue[i];
    }

    public static void run()
    {
        for (iterator = 0; iterator < runQueue.Count;iterator++)
        {
            if(GetAt(iterator) != null)
                GetAt(iterator).RunThis();
        }
    }

    public static ControlStatements Next()
    {

        if (runQueue.Count <= 0)
            return null;
        else
        {
            return (ControlStatements)runQueue[iterator+1];
        }
    }

    public static void IncrementIterator() { iterator++; }
}

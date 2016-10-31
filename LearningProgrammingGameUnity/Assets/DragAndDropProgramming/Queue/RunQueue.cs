
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
        //Debug.Log("there was an object there already! " + RunQueue.GetAt(position).GetControlType());
        runQueue.RemoveAt(position);
        runQueue.Insert(position, statement);

        //Debug.Log("There was nothing here ");
        //runQueue.Add(statement);    
    }
    public static void RemoveFromQueue(ControlStatements statement)
    {
        runQueue.Remove(statement);
    }
    public static void RemoveFromQueue(int position)
    {
        //Debug.Log("setting " + position + " to null...");
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
        ConsoleUI.ResetText();
        int indexInCorrectionList = 0;
       
        for (iterator = 0; iterator < runQueue.Count;iterator++)
        {
            if(GetAt(iterator) != null)
            {
                GetAt(iterator).RunThis();
                //if(ShowAndHideDragAndDrop.WhichAccessPanel == 1)
                 //   roomOne.IsThisResultCorrect(indexInCorrectionList, iterator);
                indexInCorrectionList++;
                //Debug.Log("running " + iterator);
            }
            //else
                //Debug.Log("running " + iterator + " was null");
        }
        if (false)//roomOne.IsFinalResultTrue())
        {
            //open door
            ConsoleUI.AddText("\nCorrect code...");
            GameObject sphere = GameObject.Find("Sphere");
            sphere.SetActive(false);
            //Debug.Log("open door");
        }
        else
        {
            //Error sound
            ConsoleUI.AddText("\nWrong code! Please try again...");
            //Debug.Log("Wrong");
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

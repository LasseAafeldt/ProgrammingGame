
using UnityEngine;
using System.Collections;

public class RunQueue {
    private static ArrayList runQueue = new ArrayList();
    private static int iterator = 0;
    public static int numberOfRuns = 0;
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
        for (int i = 0; i < CanvasHandler.DropPanel.transform.childCount; i++)
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
//        Debug.Log("There was nothing here ");
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
		//Debug.Log ("at i = " + runQueue[i]);
        return (ControlStatements)runQueue[i];
    }
    public static void ResetQueue()
    {
        runQueue.Clear();
		InitializeQueue ();
    }

    public static void run()
    {
        numberOfRuns = 0;
        ConsoleUI.ResetText();   
        for (iterator = 0; iterator < runQueue.Count;iterator++)
        {
            if(GetAt(iterator) != null)
            {
                GetAt(iterator).RunThis();
                numberOfRuns++;
            }
        }
        Debug.Log(numberOfRuns);
        switch (ManagerScript.ActiveID)
        {
            case 1: 
                Debug.Log("Room one is active! Checking results...");
                room1AccessPanelAssignement.IsEachResultCorrect();
                //open door
                if (room1AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code...");
                    GameObject.Find("DoorAnimationFixer").GetComponent<DoorAnimation>().ChangeState();
                }
                else
                {
                    //Error sound
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                    //Debug.Log("Wrong");
                }
                break;
            case 2:
                room2_AdditionAssignment.IsEachResultCorrect();
                if (room2_AdditionAssignment.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code...");
                    GameObject.Find("DoorAnimationFixerOfficeHallway").GetComponent<DoorAnimation>().ChangeState();
                }
                else
                {
                    //Error sound
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                    //Debug.Log("Wrong");
                }
                break;
            case 6:
                room6AccessPanelAssignement.IsEachResultCorrect();
                if (room6AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code...");
                    GameObject.Find("DoorAnimationFixerMain").GetComponent<DoorAnimation>().ChangeState();
                }
                else
                {
                    //Error sound
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                    //Debug.Log("Wrong");
                }
                break;
            case 7:
                room7AccessPanelAssignement.IsEachResultCorrect();
                if (room7AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code...");
                }
                else
                {
                    //Error sound
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                    //Debug.Log("Wrong");
                }
                break;
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

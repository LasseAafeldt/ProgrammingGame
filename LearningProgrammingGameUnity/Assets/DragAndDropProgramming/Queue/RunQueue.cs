﻿
using UnityEngine;
using System.Collections;

public class RunQueue {
    private static ArrayList runQueue = new ArrayList();
    private static int iterator = 0;
    public static int numberOfRuns = 0;
    public static int GetSize()
    {
        return runQueue.Count;
    }
    private static void InitializeQueue()
    {
        for (int i = 0; i < CanvasHandler.DropPanel.transform.childCount; i++)
            runQueue.Add(null);
    }
    public static void AddToQueue(ControlStatements statement, int position)
    {
        runQueue.RemoveAt(position);
        runQueue.Insert(position, statement);
    }
    public static void RemoveFromQueue(ControlStatements statement)
    {
        runQueue.Remove(statement);
    }
    public static void RemoveFromQueue(int position)
    {
        runQueue[position] = null;
    }
    public static int GetCurrentI()
    {
        return iterator;
    }
    public static ControlStatements GetAt(int i)
    {
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
		switch (ManagerScript.GetActiveID())
        {
            case 1: 
                room1AccessPanelAssignement.IsEachResultCorrect();
                if (room1AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code!");
                    GameObject.Find("DoorAnimationFixer").GetComponent<DoorAnimation>().Open();
                }
                else
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                break;
            case 2:
                room2_AdditionAssignment.IsEachResultCorrect();
                if (room2_AdditionAssignment.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code! Door opened");
                    GameObject.Find("OfficeHallwayDoorFixer").GetComponent<DoorAnimation>().Open();
                }
                else
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                break;
            case 3:
                room3AccessPanelAssignement.IsEachResultCorrect();
                if (room3AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect!");
                    CanvasHandler.Manual.SetActive(true);
                }
                else
                    if(!(bool)room3AccessPanelAssignement.IsEachCorrect[0])
                        ConsoleUI.AddText("\nYou didnt collect all of the books! Please collect the last books");
                    else if (!(bool)room3AccessPanelAssignement.IsEachCorrect[1])
                        ConsoleUI.AddText("\nThe number you entered is not the number of books you collected. Please enter the correct number.");
                break;
            case 4:
                room4AccessPanelAssignement.IsEachResultCorrect();
                if (room4AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect! Now the temperature is fixed");
                    CanvasHandler.Wires.SetActive(true);
                }
                else
                    ConsoleUI.AddText("\nWrong temperature! Please try again...");
                break;
            case 6:
                room6AccessPanelAssignement.IsEachResultCorrect();
                if (room6AccessPanelAssignement.IsFinalResultTrue())
                {
                    ConsoleUI.AddText("\nCorrect code!");
                    GameObject.Find("DoorAnimationFixerMain").GetComponent<DoorAnimation>().Open();
                }
                else
                {
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                    CanvasHandler.Player.transform.position = CharacterControll.StartPos;
                }
                break;
            case 7:
                room7AccessPanelAssignement.IsEachResultCorrect();
                if (room7AccessPanelAssignement.IsFinalResultTrue())
                    ConsoleUI.AddText("\nCorrect code!");
                else
                    ConsoleUI.AddText("\nWrong code! Please try again...");
                break;
        }
    }

    public static ControlStatements Next()
    {
        if (runQueue.Count <= 0)
            return null;
        else
            return (ControlStatements)runQueue[iterator+1];
    }

    public static void IncrementIterator() { iterator++; }
}

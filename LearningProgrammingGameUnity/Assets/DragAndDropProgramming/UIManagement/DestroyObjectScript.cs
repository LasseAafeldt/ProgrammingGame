using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DestroyObjectScript : MonoBehaviour, IDropHandler
{ 
    public void OnDrop(PointerEventData eventData)
    {

        if(DragHandler.itemBeingDragged != GameObject.Find("AdditionButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("SubtractionButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("DivisionButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("IfStatementButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("MultiplicationButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("IfElseStatementButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("ForLoopButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("WhileLoopButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("VariableButton"))
        {
            //Debug.Log("Destroying object : " + DragHandler.itemBeingDragged);
            //Debug.Log("Removing " + DragHandler.index);
            //Debug.Log(RunQueue.GetAt(DragHandler.index).GetControlType());
            //Debug.Log(" from queue at index " + DragHandler.index);
            RunQueue.RemoveFromQueue(DragHandler.index);
            Destroy(DragHandler.itemBeingDragged);
        }
    }
       
}

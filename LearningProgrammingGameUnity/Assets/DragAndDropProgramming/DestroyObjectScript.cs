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
            DragHandler.itemBeingDragged != GameObject.Find("MultiplicationButton"))
        {
            Destroy(DragHandler.itemBeingDragged);
        }
    }
       
}

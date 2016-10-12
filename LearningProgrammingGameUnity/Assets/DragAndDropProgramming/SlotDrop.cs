using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SlotDrop : MonoBehaviour, IDropHandler {
    private int indexBeingDroppedOn = -1;
    public GameObject item {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            //DragHandler.itemBeingDragged.transform.SetParent(transform);
            GameObject copyObject = Instantiate(DragHandler.itemBeingDragged) as GameObject;
            copyObject.transform.SetParent(transform);
            copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            copyObject.transform.localScale= new Vector3(1 , 0.5f, 0);
            //indexBeingDroppedOn = GameObject.Find("DropPanel").GetComponent();
            Debug.Log(indexBeingDroppedOn);
            AddComponentToQueue();
        }
    }

    private void AddComponentToQueue()
    {
        /*if ()
        {

        }
        Debug.Log();*/
        int i=0;
        if (DragHandler.itemBeingDragged == GameObject.Find("AdditionButton"))
        {
            new Addition(1, 1).AddToQueue(i);
            Debug.Log("added addtion to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("SubtractionButton"))
        {
            new Subtraction(1, 1).AddToQueue(1);
            Debug.Log("added subtraction to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("DivisionButton"))
        {
            new Division(1, 1).AddToQueue(2);
            Debug.Log("added division to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("MultiplicationButton"))
        {
            new Multiplication(1, 1).AddToQueue(3);
            Debug.Log("added multiplication to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("IfStatementButton"))
        {
            new IfStatement(1.0f, "<", 1.0f).AddToQueue(4);
            Debug.Log("added if statement to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("IfElseStatementButton"))
        {
            new IfElseStatement(1.0f, "<", 1.0f).AddToQueue(5);
            Debug.Log("added if else statement to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("ForLoopButton"))
        {
            new ForLoop(2).AddToQueue(6);
            Debug.Log("added for loop to queue ");
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("WhileLoopButton"))
        {
            new WhileLoop().AddToQueue(7);
            Debug.Log("added while loop to queue ");
        }
    }
}

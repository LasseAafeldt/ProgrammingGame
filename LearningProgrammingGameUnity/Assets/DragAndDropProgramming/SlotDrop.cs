using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class SlotDrop : MonoBehaviour, IDropHandler {
    private int indexBeingDroppedOn = -1;
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
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
            indexBeingDroppedOn = transform.GetSiblingIndex();
            //Debug.Log("Droped on index = " + indexBeingDroppedOn);
            var left = copyObject.transform.GetChild(1).GetComponent<TextChangeListener>().number;
            var right = copyObject.transform.GetChild(2).GetComponent<TextChangeListener>().number;
            string condition = "";   
            if (copyObject.transform.GetChild(3) != null)
                condition = copyObject.transform.GetChild(3).GetComponent<TextChangeListener>().text;
            Debug.Log("gui text = ");
            AddComponentToQueue(left, right, condition);
        }
    }

    private void AddComponentToQueue(float left, float right, string condition)
    {
        if (DragHandler.itemBeingDragged == GameObject.Find("AdditionButton"))
        {
            new Addition(left, right).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added addtion to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("SubtractionButton"))
        {
            new Subtraction(left, right).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added subtraction to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("DivisionButton"))
        {
            new Division(left, right).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added division to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("MultiplicationButton"))
        {
            new Multiplication(left, right).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added multiplication to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("IfStatementButton"))
        {
            new IfStatement(left, "<", right).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added if statement to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("IfElseStatementButton"))
        {
            new IfElseStatement(left, "<", right).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added if else statement to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("ForLoopButton"))
        {
            new ForLoop((int)left).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added for loop to queue in index " + indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("WhileLoopButton"))
        {
            new WhileLoop().AddToQueue(indexBeingDroppedOn);
            Debug.Log("added while loop to queue in index " + indexBeingDroppedOn);
        }
    }
}

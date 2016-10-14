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
            //Sets the index which the object have been dropped on
            indexBeingDroppedOn = transform.GetSiblingIndex();

            //Tries to create a 3D component (left,right,condition)
            try
            {
                var left = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                var right = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                var condition = DragHandler.itemBeingDragged.transform.GetChild(3).GetComponent<TextChangeListener>().text;
                AddComponentToQueue(left, right, condition);
            }
            //Else tries to create component with 2 values (left,right)
            catch (Exception e)
            {
                try
                {
                    var left = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                    var right = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                    AddComponentToQueue(left, right);
                }
                catch (Exception e2)
                {
                    var left = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                    AddComponentToQueue(left);
                }
            }
        }
    }
    //Adds 3D (left,right,condition) GameComponent to the RunQueue
    private void AddComponentToQueue(float left, float right, string condition)
    {
        //if numbers are not empty
        if (left != 0 && right != 0) {
            //if statement 
            if (DragHandler.itemBeingDragged == GameObject.Find("IfStatementButton") &&
                condition != null && !condition.Equals("0") && !condition.Equals(""))
            {
                new IfStatement(left, condition, right).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added if statement to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
            //if else statement
            if (DragHandler.itemBeingDragged == GameObject.Find("IfElseStatementButton") &&
                condition != null && !condition.Equals("0") && !condition.Equals(""))
            {
                new IfElseStatement(left, condition, right).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added if else statement to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
            //While Loop
            if (DragHandler.itemBeingDragged == GameObject.Find("WhileLoopButton"))
            {
                new WhileLoop().AddToQueue(indexBeingDroppedOn);
                Debug.Log("added while loop to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
        }
    }
    //Adds 2D (left,right) GameComponent to the RunQueue
    private void AddComponentToQueue(float left, float right)
    {
        if (left != 0 && right != 0)
        {
            if (DragHandler.itemBeingDragged == GameObject.Find("AdditionButton"))
            {
                new Addition(left, right).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added addtion to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
            if (DragHandler.itemBeingDragged == GameObject.Find("SubtractionButton"))
            {
                new Subtraction(left, right).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added subtraction to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
            if (DragHandler.itemBeingDragged == GameObject.Find("DivisionButton"))
            {
                new Division(left, right).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added division to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
            if (DragHandler.itemBeingDragged == GameObject.Find("MultiplicationButton"))
            {
                new Multiplication(left, right).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added multiplication to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
        }
    }

    private void AddComponentToQueue(float left)
    {
        if (DragHandler.itemBeingDragged == GameObject.Find("ForLoopButton"))
        {
            new ForLoop((int)left).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added for loop to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
    }

    private void InstantiateGameObject()
    {
        //Copys the gameobject that is being draged and if it can put it into another parent it does
        GameObject copyObject = Instantiate(DragHandler.itemBeingDragged) as GameObject;
        copyObject.transform.SetParent(transform);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(0.9f, 0.5f, 0);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class SlotDrop : MonoBehaviour, IDropHandler {
    //used for finding index being dropped on (used for the queue)
    private int indexBeingDroppedOn = -1;
    //finds if there is an game object that is being dropped on
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
        //if gameobject exists
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
                    //Debug.Log(" left = " + left + " right = " + right );
                    AddComponentToQueue(left, right);
                }
                //Else tries to create component with 1 value
                catch (Exception e2)
                {
                    var number = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                    if (number != null)
                        AddComponentToQueue(number);
                    else
                    {
                        var strng = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().text;
                        AddComponentToQueue(strng);
                    }
                    DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().ResetVariables();
                }
            }
        }
    }
    //Adds 3D (left,right,condition) GameComponent to the RunQueue
    private void AddComponentToQueue(float? lef, float? righ, string condition)
    {
        float left;
        float right;
        //if numbers are not empty
        if (lef != null && righ != null) {
            left = lef.Value;
            right = righ.Value;
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
    private void AddComponentToQueue(float? lef, float? righ)
    {
        //Debug.Log(" lef = " + lef + " righ = " + righ);
        float left;
        float right;
        if (lef != null && righ != null)
        {
            left = lef.Value;
            right = righ.Value;
            //Debug.Log(" local left = " + left + " local right = " + right);

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
    //Adds 1D component to queue
    private void AddComponentToQueue(float? left)
    {
        // If item being dragged is either for or variable button then
            //it creates for loop and variable components and add them to queue
        //for loop
        if (DragHandler.itemBeingDragged == GameObject.Find("ForLoopButton"))
        {
            new ForLoop((int)left).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added for loop to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
        //variable
        if (DragHandler.itemBeingDragged == GameObject.Find("VariableButton"))
        {
            new Variables(left).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added number varible to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
    }
    //add component with single variable of type string
    private void AddComponentToQueue(String left)
    {
        //variable
        if (DragHandler.itemBeingDragged == GameObject.Find("VariableButton"))
        {
            new Variables(left).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added string variable to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
    }

    private void InstantiateGameObject()
    {
        //Copys the gameobject that is being draged and if it can put it into another parent
        GameObject copyObject = Instantiate(DragHandler.itemBeingDragged) as GameObject;
        copyObject.transform.SetParent(transform);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(0.9f, 0.5f, 0);
    }
}

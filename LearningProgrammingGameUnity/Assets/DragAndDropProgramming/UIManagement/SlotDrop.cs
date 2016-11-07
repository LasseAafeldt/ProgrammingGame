using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class SlotDrop : MonoBehaviour, IDropHandler {
    //used for finding index being dropped on (used for the queue)
    private int indexBeingDroppedOn = -1;
    private String log;
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
            //Debug.Log("indexBeingDroppedOn = " + indexBeingDroppedOn);
            //Tries to create a 3D component (left,right,condition)
            try
            {
                //Debug.Log("trying to create 3d component...");
                var left = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                var right = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                var condition = DragHandler.itemBeingDragged.transform.GetChild(3).GetComponent<TextChangeListener>().text;
                AddComponentToQueue(left, right, condition);
            }
            //Else tries to create component with 2 values (left,right)
            catch (Exception e)
            {
                //Debug.Log("Failed!");
                try
                {
                    log = e.StackTrace;
                    //Debug.Log("trying to create 2d component...");
                    var left = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                    var right = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                    //Debug.Log(" left = " + left + " right = " + right );
                    if (left != null && right != null)
                    {
                        //Debug.Log("Got into the if statement");
                        AddComponentToQueue(left, right);
                    }
                    else
                        throw new ArgumentNullException("2D component had null in either left or right");
                }
                catch (Exception e2)
                {
                    //Debug.Log("Failed! Reason: " + e2.StackTrace);
                    log = e2.StackTrace;
                    //try to create variable
                    try
                    {
                        //Debug.Log("trying to create variable...");
                        var name = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().text;
                        var text = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().text;
                        float? number = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                        if (name != null)
                        {
                            if (number != null)
                            {
                                //Debug.Log("creating variable with name = " +name +" and with value = " + number);
                                AddComponentToQueue(name,number.Value);
                            }
                            else if(text != null)
                            {
                                //Debug.Log("creating variable with name = " + name + " and with value = " + text);
                                AddComponentToQueue(name, text);
                            }
                        }
                        //DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().ResetVariables();
                    }
                    //Else tries to create component with 1 value
                    catch (Exception e3)
                    {
                        log = e3.StackTrace;
                        //Debug.Log("Failed!");
                        //Debug.Log("trying to create for loop...");
                        var number = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().number;
                        if (number != null)
                            AddComponentToQueue(number);

                    }
                }
            }
        }
    }
    //Adds 3D (left,right,condition) GameComponent to the RunQueue
    private void AddComponentToQueue(float? left, float? right, string condition)
    {

        //if numbers are not empty
        if (left != null && right != null) {
            //if statement 
            if (DragHandler.itemBeingDragged == GameObject.Find("IfStatementButton") &&
                condition != null && !condition.Equals("0") && !condition.Equals(""))
            {
                new IfStatement(left.Value, condition, right.Value).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added if statement to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
            //if else statement
            if (DragHandler.itemBeingDragged == GameObject.Find("IfElseStatementButton") &&
                condition != null && !condition.Equals("0") && !condition.Equals(""))
            {
                new IfElseStatement(left.Value, condition, right.Value).AddToQueue(indexBeingDroppedOn);
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
    private void AddComponentToQueue(float? left, float? right)
    {
        if (DragHandler.itemBeingDragged == GameObject.Find("AdditionButton"))
        {
            //Debug.Log("trying to add addtion");
            new Addition(left.Value, right.Value).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added addtion to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("SubtractionButton"))
        {
            new Subtraction(left.Value, right.Value).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added subtraction to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("DivisionButton"))
        {
            new Division(left.Value, right.Value).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added division to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("MultiplicationButton"))
        {
            new Multiplication(left.Value, right.Value).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added multiplication to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
    }
    //Adds 1D component to queue
    private void AddComponentToQueue(float? left)
    {
        //for loop
        if(left != null)
            if (DragHandler.itemBeingDragged == GameObject.Find("ForLoopButton"))
            {
                new ForLoop((int)left.Value).AddToQueue(indexBeingDroppedOn);
                Debug.Log("added for loop to queue in index " + indexBeingDroppedOn);
                InstantiateGameObject();
            }
    }

    //add component variable of type string
    private void AddComponentToQueue(String name, String value)
    {
        //variable
        if (DragHandler.itemBeingDragged == GameObject.Find("VariableButton"))
        {
            new Variables(name, value).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added string variable to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
    }
    //add component variable of type float
    private void AddComponentToQueue(String name, float value)
    {
        //variable
        if (DragHandler.itemBeingDragged == GameObject.Find("VariableButton"))
        {
            new Variables(name, value).AddToQueue(indexBeingDroppedOn);
            Debug.Log("added number varible to queue in index " + indexBeingDroppedOn);
            InstantiateGameObject();
        }
    }

    private void InstantiateGameObject()
    {
        //Copys the gameobject that is being draged and if it can put it into another parent
        GameObject copyObject = Instantiate(DragHandler.itemBeingDragged) as GameObject;
        copyObject.transform.SetParent(transform);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
    }
    private void PrintLog() { Debug.Log(log);}
}

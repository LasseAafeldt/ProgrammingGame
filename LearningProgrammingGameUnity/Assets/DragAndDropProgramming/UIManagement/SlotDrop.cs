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
			//Debug.Log("item " + DragHandler.itemBeingDragged+ " being dropped on indexBeingDroppedOn = " + indexBeingDroppedOn);
            //Tries to create a 3D component (left,right,condition)
            try
            {
                //Debug.Log("trying to create 3d component...");

                var left = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                var right = DragHandler.itemBeingDragged.transform.GetChild(3).GetComponent<TextChangeListener>().number;
                var condition = DragHandler.itemBeingDragged.transform.GetChild(4).GetComponent<TextChangeListener>().text;
				//Debug.Log("left " + left + " right " + right + " condition " + condition);
                AddComponentToQueue(left, right, condition);
            }
            //Else tries to create component with 2 values (left,right)
            catch (Exception e)
            {
//                Debug.Log("Failed!");
                try
                {
					//Debug.Log("trying to create 2d component...");
					if (DragHandler.itemBeingDragged.transform.gameObject.tag == "TwoInputBut")
					{
                        //Debug.Log("DragHandler.itemBeingDragged.transform.gameObject.tag == TwoInputBut");
						log = e.StackTrace;
		                var left = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
		                var right = DragHandler.itemBeingDragged.transform.GetChild(3).GetComponent<TextChangeListener>().number;
		                //Debug.Log(" left = " + left + " right = " + right);
						AddComponentToQueue(left, right);
					}
					else
						throw new Exception();
                    
                }
                catch (Exception e2)
                {
                    //Debug.Log("Failed! Reason: " + e2.StackTrace);
                    log = e2.StackTrace;
                    //try to create variable
                    try
                    {
                        if (DragHandler.itemBeingDragged.transform.gameObject.tag == "VariableBut")
                        {
                            //Debug.Log("trying to create variable...");
                            var name = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().text;
                            var text = DragHandler.itemBeingDragged.transform.GetChild(3).GetComponent<TextChangeListener>().text;
                            float? number = DragHandler.itemBeingDragged.transform.GetChild(3).GetComponent<TextChangeListener>().number;
                            if (name != null)
                            { 
                                //Debug.Log("name != null " + name);
                                if (number != null)
                                {
                                    //Debug.Log("number != null " + number);
                                    //Debug.Log("creating variable with name = " +name +" and with value = " + number);
                                    AddComponentToQueue(name, number.Value);
                                }
                                else if (text != null)
                                {
                                    //Debug.Log("text != null " + text);
                                    //Debug.Log("creating variable with name = " + name + " and with value = " + text);
                                    AddComponentToQueue(name, text);
                                }
                            }
                        }
                        else
                            throw new Exception();
                        //DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<TextChangeListener>().ResetVariables();
                    }
                    //Else tries to create component with 1 value
                    catch (Exception e3)
                    {
                        if (DragHandler.itemBeingDragged.transform.gameObject.tag == "LoopsBut")
                        {
                            log = e3.StackTrace;
                            //Debug.Log("Failed!");
                            //Debug.Log("trying to create for loop...");
                            var number = DragHandler.itemBeingDragged.transform.GetChild(2).GetComponent<TextChangeListener>().number;
                            AddComponentToQueue(number);
                        }
                        try
                        {
                            //Debug.Log("Trying to create equation...");
                            AddComponentToQueue();
                        }
                        catch (Exception e4)
                        {
                            log += e4.StackTrace;
                        }
                    }
                }
            }
        }
    }
    //Adds 3D (left,right,condition) GameComponent to the RunQueue
    private void AddComponentToQueue(float? left, float? right, string condition)
    {
        //if statement 
		if (DragHandler.itemBeingDragged == GameObject.Find("IfStatementButton"))
        {
			InstantiateGameObject();
			//Debug.Log ("Item being dragged == if statement");
            new IfStatement(left, condition, right).AddToQueue(indexBeingDroppedOn);
        }
        //if else statement
        if (DragHandler.itemBeingDragged == GameObject.Find("IfElseStatementButton"))
        {
			InstantiateGameObject();
            new IfElseStatement(left, condition, right).AddToQueue(indexBeingDroppedOn);
        }
        //While Loop
        if (DragHandler.itemBeingDragged == GameObject.Find("WhileLoopButton"))
        {
			InstantiateGameObject();
            new WhileLoop().AddToQueue(indexBeingDroppedOn);
        }
    }
    //Adds 2D (left,right) GameComponent to the RunQueue
    private void AddComponentToQueue(float? left, float? right)
    {
        if (DragHandler.itemBeingDragged == GameObject.Find("AdditionButton"))
        {
			InstantiateGameObject();
            //Debug.Log("trying to add addition");
            new Addition(left, right).AddToQueue(indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("SubtractionButton"))
        {
			InstantiateGameObject();
            new Subtraction(left, right).AddToQueue(indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("DivisionButton"))
        {
			InstantiateGameObject();
            new Division(left, right).AddToQueue(indexBeingDroppedOn);
        }
        if (DragHandler.itemBeingDragged == GameObject.Find("MultiplicationButton"))
        {
			InstantiateGameObject();
            new Multiplication(left, right).AddToQueue(indexBeingDroppedOn);
        }
    }
    //Adds 1D component to queue
    private void AddComponentToQueue(float? left)
    {
        //for loop
        if (DragHandler.itemBeingDragged == GameObject.Find("ForLoopButton"))
        {
			InstantiateGameObject();
            Debug.Log("Trying to add for loop...");
            new ForLoop(left).AddToQueue(indexBeingDroppedOn);
        }
    }

    //add component variable of type string
    private void AddComponentToQueue(String name, String value)
    {
        //variable
        if (DragHandler.itemBeingDragged == GameObject.Find("VariableButton"))
        {
            InstantiateGameObject();
            new Variables(name, value).AddToQueue(indexBeingDroppedOn);
        }
    }
    //add component variable of type float
    private void AddComponentToQueue(String name, float value)
    {
        //variable
        if (DragHandler.itemBeingDragged == GameObject.Find("VariableButton"))
        {
			InstantiateGameObject();
            new Variables(name, value).AddToQueue(indexBeingDroppedOn);
        }
    }

    //Adds 0D component to queue
    private void AddComponentToQueue()
    {
        //Equation
        if (DragHandler.itemBeingDragged.CompareTag("NoInputBut"))
        {
            InstantiateGameObject();
            //Debug.Log("added for equation to queue in index " + indexBeingDroppedOn);
            String textt = DragHandler.itemBeingDragged.transform.GetChild(1).GetComponent<Text>().text;
            //Debug.Log("added for equation to queue in index " + indexBeingDroppedOn);
            new Equation(textt).AddToQueue(indexBeingDroppedOn);
            //Debug.Log("added for equation to queue in index " + indexBeingDroppedOn);
        }
    }

    private void InstantiateGameObject()
    {
        //Copys the gameobject that is being draged and if it can put it into another parent
        GameObject copyObject = Instantiate(DragHandler.itemBeingDragged) as GameObject;
        copyObject.transform.SetParent(transform);
        copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        copyObject.transform.localScale = new Vector3(1f, 1f, 0);
        if (DragHandler.itemBeingDragged != GameObject.Find("AdditionButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("SubtractionButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("DivisionButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("IfStatementButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("MultiplicationButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("IfElseStatementButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("ForLoopButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("WhileLoopButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("VariableButton") &&
            DragHandler.itemBeingDragged != GameObject.Find("EquationButton"))
        {
            RunQueue.RemoveFromQueue(DragHandler.index);
            Destroy(DragHandler.itemBeingDragged);
        }
    }
    private void PrintLog() { Debug.Log(log);}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TextChangeListener : MonoBehaviour {
    public float? number = null;
    public string text = null;
    InputField input;
    // Use this for initialization
    void Start () {
        input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SubmitName(string arg0)
    {
        float number1;
        text = arg0;
        //checks if the text entered in the field can be converted to int

		if (float.TryParse(arg0, out number1)) 
        {
            //converts to float
            number = float.Parse(arg0);
            text = null;
            //Debug.Log("float conversion possible " + arg0 + " number = " + this.number);
        }
        //Checks if the input field is the condition field and there is input in the field
        /*else if (gameObject != null )//&& gameObject.GetInstanceID() == GameObject.Find("Condition").GetInstanceID())
        {
            //Checks if this is a acceptable condition. 
            //This is inverted so if this is not accepted then reset'
            Debug.Log("game object is condition");
            if (!arg0.Equals("<") &&
             !arg0.Equals("<=") &&
             !arg0.Equals(">") &&
             !arg0.Equals(">=") &&
             !arg0.Equals("==") &&
             !arg0.Equals("!="))
            {
                InputField output = gameObject.GetComponent<InputField>();
                output.text = "0";
                number = null;
            }
        }*/
        ChangedInDropPanel();
        //Debug.Log("text = (" + text + ")");
    }

    private void ChangedInDropPanel()
    {
        if (gameObject.transform.IsChildOf(CanvasHandler.DropPanel.transform))
        {
//			Debug.Log ("Is child of drop panel");
            int indexQueue = transform.parent.parent.GetSiblingIndex();
            int indexInParent = transform.GetSiblingIndex();
            if (transform.parent.tag.Equals("VariableBut"))
            {
                //Debug.Log("3number = " + number2);
                if (number != null)
                {
                    if (indexInParent == 3)
                    {
                        //Debug.Log("4number = " + number2);
                        RunQueue.GetAt(indexQueue).SetRight(number.Value);
                    }
                }
                else if (text != null)
                {
                    //Debug.Log("variable being changed...");
                    if (indexInParent == 2)
                        RunQueue.GetAt(indexQueue).SetVarName(text);
                    if (indexInParent == 3)
                    {
                        RunQueue.GetAt(indexQueue).SetRight(text, indexQueue);
                        //Debug.Log("2number = " + number2);
                    }
                }
                Debug.Log("Changed in drop panel at index " + indexQueue + " type = " + RunQueue.GetAt(indexQueue).GetControlType());
            }

			if (transform.parent.tag.Equals("TwoInputBut"))
			{
				//Debug.Log("3number = " + number2);
				if (number != null)
				{
					Debug.Log ("queue index " + indexQueue);
					Debug.Log(" "  + RunQueue.GetAt(indexQueue).ToString());
					//Debug.Log("variable being changed...");
					if (indexInParent == 2)
						RunQueue.GetAt(indexQueue).SetLeft(number.Value);
					if (indexInParent == 3)
					{
						//Debug.Log("4number = " + number2);
						RunQueue.GetAt(indexQueue).SetRight(number.Value);
					}
				}
				Debug.Log("Changed in drop panel at index " + indexQueue + " type = " +RunQueue.GetAt(indexQueue).GetControlType());
			}

			if (transform.parent.tag.Equals("ThreeInputBut"))
			{
				//Debug.Log("3number = " + number2);
				if (number != null || text != null)
				{
					//Debug.Log("variable being changed...");
					if (indexInParent == 2)
						RunQueue.GetAt(indexQueue).SetLeft(number.Value);
					if (indexInParent == 3)
					{
						//Debug.Log("4number = " + number2);
						RunQueue.GetAt(indexQueue).SetRight(number.Value);
					}
					if (indexInParent == 4)
					{
//						Debug.Log("changed condition to " + text);
						RunQueue.GetAt(indexQueue).SetCondition(text);
					}
				}
				Debug.Log("Changed in drop panel at index " + indexQueue + " type = " +RunQueue.GetAt(indexQueue).GetControlType());
			}
        }
    }

    public void ResetVariables()
    {
        number = null;
        text = null;
    }
}
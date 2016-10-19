using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextChangeListener : MonoBehaviour {
    public float? number = null;
    public string text = null;

    // Use this for initialization
    void Start () {
        var input = gameObject.GetComponent<InputField>();
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
        if (float.TryParse(arg0, out number1) && 
            gameObject.GetInstanceID() != GameObject.Find("Condition").GetInstanceID())
        {
            //converts to float
            number = float.Parse(arg0);
            //Debug.Log("float conversion possible " + arg0 + " number = " + this.number);
        }
        //Checks if the input field is the condition field and there is input in the field
        else if (gameObject.GetInstanceID() == GameObject.Find("Condition").GetInstanceID())
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
        }
        ChangedInDropPanel();
        //Debug.Log("text = (" + text + ")");
    }
    private void ChangedInDropPanel()
    {
        if (gameObject.transform.IsChildOf(GameObject.Find("DropPanel").transform))
        {
            int indexQueue = transform.parent.parent.GetSiblingIndex();
            int indexInParent = transform.GetSiblingIndex();
            if (number != null)
            {
                if(indexInParent == 1)
                    RunQueue.GetAt(indexQueue).SetLeft(number.Value);
                if(indexInParent == 2)
                    RunQueue.GetAt(indexQueue).SetRight(number.Value);
                if(indexInParent == 3)
                    RunQueue.GetAt(indexQueue).SetCondition(text);
            }
            //else
            //    RunQueue.GetAt(indexQueue).SetLeft(text);
            Debug.Log("Changed in drop panel at index " + indexQueue + " type = " +RunQueue.GetAt(indexQueue).GetControlType());
        }
    }
    public void ResetVariables()
    {
        number = null;
        text = null;
    }
}
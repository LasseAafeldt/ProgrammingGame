using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextChangeListener : MonoBehaviour {
    public int number;
    public string text;

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
        text = arg0;
        //checks if the text entered in the field can be converted to int
        if (int.TryParse(arg0, out number) && 
            gameObject.GetInstanceID() != GameObject.Find("Condition").GetInstanceID())
        {
            //converts to ints
            number = int.Parse(arg0);
        }
        //Checks if the input field is the condition field and there is input in the field
        else if (gameObject.GetInstanceID() == GameObject.Find("Condition").GetInstanceID())
        {
            //Checks if this is a acceptable condition. 
            //This is inverted so if this is not accepted then reset
            if (!arg0.Equals("<") &&
             !arg0.Equals("<=") &&
             !arg0.Equals(">") &&
             !arg0.Equals(">=") &&
             !arg0.Equals("==") &&
             !arg0.Equals("!="))
            {
                InputField output = gameObject.GetComponent<InputField>();
                output.text = "0";
                number = 0;
            }
        }
        Debug.Log("arg0 = (" + arg0 + ")");
    }
}

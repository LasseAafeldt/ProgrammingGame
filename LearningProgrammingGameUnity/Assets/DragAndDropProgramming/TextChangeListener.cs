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
        char[] conditionalStatements = arg0.ToCharArray();
        Debug.Log(arg0);
        if (int.TryParse(arg0, out number))
        {
           number = int.Parse(arg0);
        }
        else if (gameObject.Equals(GameObject.Find("Condition")) &&
             conditionalStatements.Length <= 2 &&
             conditionalStatements[0] == '<' ||
             conditionalStatements[0] == '=' ||
             conditionalStatements[0] == '>' ||
             conditionalStatements[0] == '!')
        {
            //skip else statement
        }
        else
        {
            InputField output = gameObject.GetComponent<InputField>();
            output.text = "0";
            number = 0;
        }
        Debug.Log(number);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class ConsoleUI : MonoBehaviour {
    private static GameObject console;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	
	}
    public static void AddText(String text)
    {
        console = CanvasHandler.Console;
        //Debug.Log("adding text " + text + " to console...");
        //Debug.Log(console);
        console.transform.GetChild(0).GetComponent<Text>().text += text + "\n";
    }
    public static void SetText(String text)
    {
        console = CanvasHandler.Console;
        console.transform.GetChild(0).GetComponent<Text>().text = text + "\n";
    }
    public static void ResetText()
    {
        console = CanvasHandler.Console;
        console.transform.GetChild(0).GetComponent<Text>().text = "";
    }

    
}

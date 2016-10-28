using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class ConsoleUI : MonoBehaviour {
    private static GameObject console;
	// Use this for initialization
	void Start () {
        console = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void AddText(String text)
    {
        //Debug.Log("adding text " + text + " to console...");
        console.GetComponent<Text>().text += text + "\n";
    }
    public static void ResetText()
    {
        console.GetComponent<Text>().text = "";
    }

    
}

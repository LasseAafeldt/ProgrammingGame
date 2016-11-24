using UnityEngine;
using System.Collections;

public class robotScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered collider");
        RedButtonPushed.parts[3] = true;
        RedButtonPushed.parts[2] = false;
    }
}

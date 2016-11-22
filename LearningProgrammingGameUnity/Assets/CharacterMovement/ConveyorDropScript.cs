using UnityEngine;
using System.Collections;

public class ConveyorDropScript : MonoBehaviour {
    static bool isInRange = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E) && isInRange)
        {
            if(ManagerScript.ConstructionModulesCollected[0])
            {
                Instantiate();
            }
            if (ManagerScript.ConstructionModulesCollected[1])
            {
                //drop module on belt :)
            }
            if (ManagerScript.ConstructionModulesCollected[2])
            {
                //drop module on belt :)
            }
            if (ManagerScript.ConstructionModulesCollected[3])
            {
                //drop module on belt :)
            }
            if (ManagerScript.ConstructionModulesCollected[4])
            {
                //drop module on belt :)
            }
        }
    }
}

﻿using UnityEngine;
using System.Collections;

public class ConveyorDropScript : MonoBehaviour {
    static GameObject[] ConstructionModule = new GameObject[5];
    static Vector3 dropPosition;
	// Use this for initialization
	void Start () {
        ConstructionModule[0] = (GameObject) Resources.Load<GameObject>("Gameobjects/gasolineContainer") as GameObject;
        ConstructionModule[1] = (GameObject)Resources.Load<GameObject>("Gameobjects/gasolineContainer") as GameObject;
        ConstructionModule[2] = (GameObject)Resources.Load<GameObject>("Gameobjects/MetalPlates") as GameObject;
        ConstructionModule[3] = (GameObject)Resources.Load<GameObject>("Gameobjects/gasolineContainer") as GameObject;
        ConstructionModule[4] = (GameObject)Resources.Load<GameObject>("Gameobjects/gasolineContainer") as GameObject;
        dropPosition = GameObject.Find("Conveyor").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float distanceToObj = Vector3.Distance(CanvasHandler.Player.transform.position, dropPosition);

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (distanceToObj < 10)
            {
                for(int i = 0; i < 5; i++) {
                    //Debug.Log(i + " " + ManagerScript.ConstructionModulesCollected[i]);
                    if (ManagerScript.ConstructionModulesCollected[i])
                    {
                        GameObject a = Instantiate(ConstructionModule[i], dropPosition, Quaternion.identity) as GameObject;
                        a.AddComponent<Rigidbody>();
                        ManagerScript.ConstructionModulesCollected[i] = !ManagerScript.ConstructionModulesCollected[i];
                        ManagerScript.ConstructionModulesHandedIn[i] = true;
                        if(i == 0)
                        {
                            a.transform.localScale = new Vector3(16.5f, 16.5f, 16.5f);
                            a.AddComponent<BoxCollider>();
                            a.GetComponent<BoxCollider>().size = new Vector3(0.06f, 0.06f, 0.06f);
                        }
                        if (i == 2)
                        {
                        }
                        return;
                    }
                }
            }
        }
    }
}

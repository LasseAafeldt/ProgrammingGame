using UnityEngine;
using System.Collections;

public class SaveTheBoxes : MonoBehaviour {
	static GameObject box1;
	static GameObject box2;
    static GameObject box3;
	static Transform resetBox;
    static GameObject AssignmentText;
	// Use this for initialization
	void Start () {
		box1 = GameObject.Find ("DropBox");
		box2 = GameObject.Find ("DropBox1");
		box3 = GameObject.Find ("DropBox2");
		resetBox = GameObject.Find ("ResetPos").transform;
        AssignmentText = GameObject.Find("Assignment5Poster");
        AssignmentText.SetActive(false);
		box1.SetActive (false);
		box2.SetActive (false);
		box3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("room5"))
        {
            other.gameObject.transform.position = resetBox.position;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = CharacterControll.StartPos;
        }
        Debug.Log("Save the boxes");
	}

	public static void ActivateAssignment5(){
		box1.SetActive (true);
		box2.SetActive (true);
		box3.SetActive (true);
        AssignmentText.SetActive(true);
    }
}

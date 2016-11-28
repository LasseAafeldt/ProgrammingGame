using UnityEngine;
using System.Collections;

public class SaveTheBoxes : MonoBehaviour {
	static GameObject box1;
	static Transform resetBox;
	static GameObject box2;
	static Transform box2Pos;
	static GameObject box3;
	static Transform box3Pos;
	static GameObject AssignmentText;
	// Use this for initialization
	void Start () {
		box1 = GameObject.Find ("DropBox");
		box2 = GameObject.Find ("DropBox1");
		box3 = GameObject.Find ("DropBox2");
		resetBox = GameObject.Find ("ResetPos").transform;
		box1.SetActive (false);
		box2.SetActive (false);
		box3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		other.gameObject.transform.position = resetBox.position;
		Debug.Log (other.gameObject);
		//other.gameObject.transform.GetChild(0).
		other.gameObject.transform.GetChild(0).transform.position = new Vector3(0,0,0);
	}

	public static void ActivateAssignment5(){
		box1.SetActive (true);
		box2.SetActive (true);
		box3.SetActive (true);
	}
}

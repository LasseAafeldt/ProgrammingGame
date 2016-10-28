using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room1_loadAccessPanelAssignment : MonoBehaviour {

	GameObject obj;
	int activeChildCount;
	// Use this for initialization
	void Start () {
		activeChildCount = 0;
		obj = gameObject;
		this.load();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load() {
		for(int i = 0; i<obj.transform.childCount; i++){
			if(i != GameObject.Find("DragSlot9").transform.GetSiblingIndex())
				obj.transform.GetChild(i).gameObject.SetActive(false);
			else
				activeChildCount ++;
		}
		//Debug.Log (new room1_AccessPanelAssignement ().GetDescription ());
		GameObject.Find ("HeaderText").GetComponent<Text> ().text = new room1_AccessPanelAssignement ().GetDescription ();
		this.scaleDragPanel ();
        obj = GameObject.Find("DropPanel");
        for (int i = 4; i < obj.transform.childCount; i++)
        {
            obj.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

	public void reset(){
		for(int i = 0; i<obj.transform.childCount; i++){
			obj.transform.GetChild(i).gameObject.SetActive(true);
		}
	}

	protected void scaleDragPanel(){

		if (activeChildCount  < 6) {
			obj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (200, 250);
			obj.GetComponent<GridLayoutGroup> ().childAlignment = TextAnchor.UpperCenter;
		} else {
			obj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (200*2, 250);
			obj.GetComponent<GridLayoutGroup> ().childAlignment = TextAnchor.MiddleCenter;
		}
	}
}

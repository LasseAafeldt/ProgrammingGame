using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class SlotDrop: MonoBehaviour, IDropHandler {
    public GameObject item {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            //DragHandler.itemBeingDragged.transform.SetParent(transform);
            GameObject copyObject = Instantiate(DragHandler.itemBeingDragged) as GameObject;
            copyObject.transform.SetParent(transform);
            copyObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            copyObject.transform.localScale= new Vector3(1 , 1, 0);
        }
    }
}

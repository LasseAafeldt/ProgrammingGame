using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DestroyObjectScript : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
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
            if(DragHandler.itemBeingDragged != GameObject.Find("Button1") &&
                DragHandler.itemBeingDragged != GameObject.Find("Button2") &&
                DragHandler.itemBeingDragged != GameObject.Find("Button3") &&
                DragHandler.itemBeingDragged != GameObject.Find("Button4") &&
                DragHandler.itemBeingDragged != GameObject.Find("Button5"))
            {
                Destroy(DragHandler.itemBeingDragged);
            }
        }
        
    }
}

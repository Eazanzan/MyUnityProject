using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
	
	public GameObject item {
		get{ 
			if(transform.childCount>0){
				return transform.GetChild(0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		//It's checked here if we have an item in the slot already
		//Default code doesnt allow another item but we will swap the items later.
		if (!item) {
			Debug.Log("Eyya");
			//If there's no item in the slot and slot type is equal to its own or inventory(0) 
			//set parent of the item to this slots transform.	
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		} else if (item != null) {
			//Swap places of items in inventory
			item.transform.SetParent(DragHandler.startParent.transform);
			DragHandler.itemBeingDragged.transform.SetParent (transform);
		}
	}
	#endregion
}

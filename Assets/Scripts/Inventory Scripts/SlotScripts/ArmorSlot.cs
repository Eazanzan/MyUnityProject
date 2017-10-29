using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorSlot : Slot, IDropHandler{

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		//It's checked here if we have an item in the slot already
		//Default code doesnt allow another item but we will swap the items later.
		WearableItemScript script = DragHandler.itemBeingDragged.GetComponent<WearableItemScript> ();
		if (script != null) {
			if (!item&&script.GetItemSlotType()==WearableItemScript.ItemSlot.Armor) {
				Debug.Log ("Eyya");
				//If there's no item in the slot and slot type is equal to its own
				//set parent of the item to this slots transform.	
				DragHandler.itemBeingDragged.transform.SetParent (transform);
			} else if (item != null&&script.GetItemSlotType()==WearableItemScript.ItemSlot.Armor) {
				//Swap places of items in inventory
				item.transform.SetParent (DragHandler.startParent.transform);
				DragHandler.itemBeingDragged.transform.SetParent (transform);
			}
		}
	}
	#endregion
}

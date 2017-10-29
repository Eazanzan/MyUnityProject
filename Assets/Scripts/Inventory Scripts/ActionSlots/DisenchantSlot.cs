using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisenchantSlot : Slot, IDropHandler {

	[SerializeField]GameObject ItemObjInst;
	[SerializeField]Sprite icon;

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		WearableItemScript script = DragHandler.itemBeingDragged.GetComponent<WearableItemScript> ();
		if (script.Disenchantable ()) {
			Debug.Log("Dissable");
			Destroy(DragHandler.itemBeingDragged);
			ItemObjInst.GetComponent<ItemObjectInster>().CreatItemObject(3,"Dust",0,0,0,0,false,false,icon);
		}
	}

	#endregion
}

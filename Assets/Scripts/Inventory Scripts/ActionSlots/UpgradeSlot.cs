using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeSlot : Slot,IDropHandler {

	Animator myAnimator;
	Transform returnParent;
	 
	void Start ()
	{
		myAnimator =GetComponent<Animator>();
	}
	
	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		//It's checked here if we have an item in the slot already
		//Default code doesnt allow another item but we will swap the items later.
		WearableItemScript script = DragHandler.itemBeingDragged.GetComponent<WearableItemScript> ();
		returnParent = DragHandler.itemBeingDragged.transform.parent;
		if (script != null) {
			if (script.Upgradable()) {
				DragHandler.itemBeingDragged.transform.SetParent (transform);
				script.Upgrade();
				myAnimator.SetBool("upgrade",true);
			} 
		}
	}
	#endregion

	public void endUpgrade ()
	{
		myAnimator.SetBool("upgrade",false);
		item.transform.SetParent(returnParent);
	}
}

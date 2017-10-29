using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectInster : MonoBehaviour {
	
	[SerializeField] GameObject deafultItemPrefab;
	[SerializeField] GameObject inventoryHandler;

	public void CreatItemObject (int creationId, string name, int propStat, int primary, int primaryVal, int vita, bool disench, bool upg, Sprite icon)
	{
		if (creationId < 3) {
			CreatWearableItemObject(creationId,name,propStat,primary,primaryVal,vita,disench,upg,icon);
		} else if (creationId == 3) {
			CreateMiscObject(name,true,icon);
		}
	}

	public void CreatWearableItemObject (int creationId,string name,int propStat,int primary,int primaryVal,int vita,bool disench,bool upg,Sprite icon)
	{
		Transform slotTransform = InventoryHandler.emptySlot();
		if (slotTransform != null) {
			GameObject itemObject = Instantiate(deafultItemPrefab,slotTransform);
			if(creationId==1)itemObject.AddComponent<WearableItemScript>().Initialize(name,propStat,primary,primaryVal,vita,WearableItemScript.ItemSlot.Weapon,disench,upg,icon);
			else if(creationId==2)itemObject.AddComponent<WearableItemScript>().Initialize(name,propStat,primary,primaryVal,vita,WearableItemScript.ItemSlot.Armor,disench,upg,icon);
		}
	}

	public void  CreateMiscObject (string name, bool stackable, Sprite icon)
	{
		
		Transform slotTransform = InventoryHandler.emptySlotStackable (name,stackable,icon);
		if (slotTransform != null) {
			GameObject itemObject = Instantiate (deafultItemPrefab,slotTransform);
			itemObject.AddComponent<StackableItemScript>().Initialize(name,stackable,icon);
		} 
}

}
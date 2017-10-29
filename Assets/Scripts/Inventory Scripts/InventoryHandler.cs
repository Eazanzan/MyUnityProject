using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
	static List<GameObject>  slots = new List<GameObject>();
	[SerializeField] GameObject inspectPanel;

	void Start ()
	{
		slots = new List<GameObject>();
		for (int i = 0; i < transform.childCount; i++) {
			slots.Add(transform.GetChild(i).gameObject);
		}
	}

	public static Transform emptySlot ()
	{
		foreach (GameObject slot in slots) {
			if (slot.transform.childCount == 0) {
				return slot.transform;
			}
		}
		return null;
	}

	public static Transform emptySlotStackable (string name, bool stackable, Sprite icon)
	{
		Transform firstEmptySlot = null;
		foreach (GameObject slot in slots) {
			if (slot.transform.childCount == 0 && firstEmptySlot == null) {
				firstEmptySlot = slot.transform;
				continue;
			} else if (slot.transform.childCount != 0&&slot.transform.GetChild (0).GetComponent<StackableItemScript> ()!=null) {
				StackableItemScript script = slot.transform.GetChild (0).GetComponent<StackableItemScript> ();
					if (slot.transform.GetChild (0).GetComponent<StackableItemScript> ().checkEqual (name, stackable, icon)) {
						slot.transform.GetChild (0).GetComponent<StackableItemScript> ().IncrementStack ();
					}
				return null;
			}

		}
		return firstEmptySlot;
	}
	
}

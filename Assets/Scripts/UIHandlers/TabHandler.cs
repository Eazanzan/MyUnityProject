using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabHandler : MonoBehaviour {
	[SerializeField] GameObject creationTab;
	[SerializeField] GameObject inventoryTab;

	public void EnableCreationTab ()
	{
		if (!creationTab.activeSelf&&inventoryTab.activeSelf) {
			inventoryTab.SetActive(false);
			creationTab.SetActive(true);
		}
	}
	public void EnableInventoryTab ()
	{
		if (creationTab.activeSelf&&!inventoryTab.activeSelf) {
			inventoryTab.SetActive(true);
			creationTab.SetActive(false);
		}
	}
}

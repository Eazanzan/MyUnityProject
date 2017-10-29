using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InspectPanelHandler : MonoBehaviour,IPointerClickHandler {
	public GameObject inspectPanel;

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		
		WearableItemScript wScript = GetComponent<WearableItemScript> ();
		StackableItemScript sScript = GetComponent<StackableItemScript> ();

		InspectPanelScript script = GameObject.Find("InspectPanel").GetComponent<InspectPanelScript> ();

		script.setOnScreen();
	
		if (wScript != null) {
			script.setGeneral(wScript.getName(),wScript.getIcon());
			script.setStats(wScript.getSLot(),wScript.getPrimary(),wScript.getPrimaryVal(),wScript.getStatVal(),wScript.getVitality());
			script.setActions(wScript.Upgradable(),wScript.Disenchantable());
		} else if (sScript != null) {
			script.setGeneral(sScript.getName(),sScript.getIcon());
		}


	}
	#endregion
}

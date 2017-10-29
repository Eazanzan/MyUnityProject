using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectPanelScript : MonoBehaviour {
	[SerializeField] GameObject icon;
	[SerializeField] GameObject nameText;
	[SerializeField] GameObject primaryText;
	[SerializeField] GameObject slotText;
	[SerializeField] GameObject statText;
	[SerializeField] GameObject vitaText;
	[SerializeField] GameObject upgradeText;
	[SerializeField] GameObject disenchantText;
	[SerializeField] GameObject onScreen;
	[SerializeField] GameObject offScreen;

	public void setOnScreen()
	{
		transform.position = onScreen.transform.position;	
	}

	public void setOffScreen ()
	{
		transform.position = offScreen.transform.position;
		slotText.SetActive(false);
		primaryText.SetActive(false);
		statText.SetActive(false);
		vitaText.SetActive(false);
		upgradeText.SetActive(false);
		disenchantText.SetActive(false);
	}

	public void setGeneral (string name,Sprite itemIcon)
	{

		nameText.GetComponent<Text>().text = name;
		icon.GetComponent<Image>().sprite = itemIcon;
	}

	public void setStats (string slot, string primTx, int primVal, int statVal, int vitaVal)
	{
		slotText.SetActive(true);
		primaryText.SetActive(true);
		statText.SetActive(true);
		vitaText.SetActive(true);
		slotText.GetComponent<Text> ().text = slot;
		primaryText.GetComponent<Text> ().text = primTx;
		primaryText.transform.GetChild(0).GetComponent<Text> ().text = primVal.ToString ();
		if(slot.Equals("Weapon"))statText.GetComponent<Text> ().text ="Attack Power";
		else if(slot.Equals("Armor"))statText.GetComponent<Text> ().text ="Defence";
		statText.transform.GetChild(0).GetComponent<Text> ().text = statVal.ToString ();
		if (vitaVal == 0) {
			vitaText.SetActive (false);
		} else {
			vitaText.SetActive(true);
			vitaText.transform.GetChild(0).GetComponent<Text>().text = vitaVal.ToString();
		}
	}

	public void setActions (bool upg, bool disch)
	{
		if (upg) upgradeText.SetActive(true);
		else upgradeText.SetActive(false);
		if(disch)disenchantText.SetActive(true);
		else disenchantText.SetActive(false);
	}

}

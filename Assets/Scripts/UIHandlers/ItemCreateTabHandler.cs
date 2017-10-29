using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCreateTabHandler : MonoBehaviour {
	List<string> names = new List<string>(){"None","Misc", "Weapon","Armor"};
	List<string> primaries = new List<string>(){"Strength","Agility","Intellect"};
	[SerializeField] Sprite[] images = new Sprite[3];
	string itemName;
	int statValue=1;
	int primaryValue=1;
	int primary;
	int vitalityValue=0;
	bool upgradable;
	bool disenchantable;
	int creationId;

	bool canCreate =false;

	[SerializeField] Image itemImage;

	[SerializeField] Dropdown dropdown;
	[SerializeField] InputField itemNameInput;
	[SerializeField] Text statName;
	[SerializeField] Text vitalityName;

	[SerializeField] Slider statValueInput;
	[SerializeField] Slider primaryValueInput;
	[SerializeField] Slider vitalityInput;

	[SerializeField] Dropdown primaryStatDropDown;

	[SerializeField] Toggle upgradableInput;
	[SerializeField] Toggle disenchantableInput;
	[SerializeField] Button creatButton;

	GameObject itemObjectInster;

	void Awake ()
	{
		PopulateList ();
		DefaultSelection();
	}


	void DefaultSelection ()
	{
		itemImage.gameObject.SetActive(false);
		creatButton.interactable =false;
		itemNameInput.gameObject.SetActive (false);
		statName.gameObject.SetActive (false);
		statValueInput.gameObject.SetActive (false);
		primaryValueInput.gameObject.SetActive(false);
		primaryStatDropDown.gameObject.SetActive(false);
		vitalityInput.gameObject.SetActive(false);
		vitalityName.gameObject.SetActive(false);
		upgradableInput.gameObject.SetActive (false);
		disenchantableInput.gameObject.SetActive (false);
	}

	void WeaponSelection ()
	{
		itemImage.sprite = images[0];
		itemImage.gameObject.SetActive(true);
		creatButton.interactable =true;
		itemNameInput.gameObject.SetActive(true);
		statName.gameObject.SetActive (true);
		statName.text = "Attack Power";
		statValueInput.gameObject.SetActive (true);
		primaryValueInput.gameObject.SetActive(true);
		primaryStatDropDown.gameObject.SetActive(true);
		vitalityInput.gameObject.SetActive(true);
		vitalityName.gameObject.SetActive(true);
		upgradableInput.gameObject.SetActive (true);
		disenchantableInput.gameObject.SetActive (true);
		creationId=1;
	}

	void ArmorSelection ()
	{
		itemImage.sprite = images[1];
		itemImage.gameObject.SetActive(true);
		creatButton.interactable =true;
		itemNameInput.gameObject.SetActive(true);
		statName.gameObject.SetActive (true);
		statName.text = "Defence";
		statValueInput.gameObject.SetActive (true);
		primaryValueInput.gameObject.SetActive(true);
		primaryStatDropDown.gameObject.SetActive(true);
		vitalityInput.gameObject.SetActive(true);
		vitalityName.gameObject.SetActive(true);
		upgradableInput.gameObject.SetActive (true);
		disenchantableInput.gameObject.SetActive (true);
		creationId=2;
	}

	void MiscSelection ()
	{
		DefaultSelection ();
		itemImage.gameObject.SetActive(true);
		itemImage.sprite = images[2];
		creatButton.interactable =true;
		itemNameInput.gameObject.SetActive (true);
		if(upgradable||disenchantable)creationId=1;
		else creationId=3;
	}

	void PopulateList()
	{
		dropdown.AddOptions(names);
		primaryStatDropDown.AddOptions(primaries);
	}

	public void DropDown_IndexChanged (int index)
	{
		if(index==0)DefaultSelection();
		else if(index==1)MiscSelection();
		else if(index==2)WeaponSelection();
		else if(index==3)ArmorSelection();
	}

	public void DropDown_PrimaryStatChanged (int index)
	{
		primary = index;	
	}

	public void ToggleUpgradable (bool val)
	{
		upgradable = val;
	}
	public void ToggleDisenchantable (bool val)
	{
	 	disenchantable=val;
	}



	public void AdjustStatVal(float statVal){
		int s= (int)statVal;
		statValueInput.transform.GetChild(0).GetComponent<Text>().text =s.ToString();
		statValue = s;
	}

	public void AdjustPrimaryVal (float primaryVal)
	{
		int s= (int)primaryVal;
		primaryValueInput.transform.GetChild(0).GetComponent<Text>().text =s.ToString();
		primaryValue = s;
	}

	public void AdjustVitalityVal (float vitaVal)
	{
		int s= (int)vitaVal;
		vitalityInput.transform.GetChild(0).GetComponent<Text>().text =s.ToString();
		vitalityValue = s;
	}

	public void CreateItemButtonPressed ()
	{	
		if (!itemNameInput.text.Equals ("")) {
				getObjInster ().GetComponent<ItemObjectInster> ().
			CreatItemObject (creationId, 
							itemNameInput.text, 
							statValue, 
							primary, 
							primaryValue, 
							vitalityValue, 
							disenchantable, 
							upgradable,
							images[creationId-1]);
		}
	}

	//Use GameObject.Find() once it's needed.
	GameObject getObjInster ()
	{
		if (itemObjectInster == null) {
			itemObjectInster = GameObject.Find("ItemObjectInstantiator");
		}
		return itemObjectInster;
	}
}

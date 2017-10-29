using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackableItemScript : MonoBehaviour {

	string itemName;
	bool stackable;
	Sprite icon;
	public int stackSize=1;
	
	public void Initialize (string name, bool stackable, Sprite icon)
	{
		itemName=name;
		this.stackable=stackable;
		this.icon=icon;
		GetComponent<Image>().sprite =icon;
	}

	public void IncrementStack ()
	{
		stackSize++;
	}

	public int getStackSize ()
	{
		return stackSize;
	}

	public string getName ()
	{
		return itemName;
	}

	public Sprite getIcon ()
	{
		return icon;
	}



	public bool checkEqual (string name, bool stackable, Sprite icon)
	{
		return this.name.Equals(name)&&this.stackable.Equals(stackable)&&this.icon.Equals(icon);
	}
}

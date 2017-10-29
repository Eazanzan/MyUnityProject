using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	protected string name;
	protected bool disenchantable;
	protected bool upgradable;

	//Empty constructor-only here for compiler error
	public Item ()
	{
	}

	//Constructor for an item without property
	public Item (string name)
	{
		this.name= name;
		this.disenchantable = false;
		this.upgradable = false;
	}

	//Constructor for an item without any specialization
	public Item (string name, bool disenchantable, bool upgradable)
	{
		this.name =name;
		this.disenchantable=disenchantable;
		this.upgradable=upgradable;
	}
	//Nonspecialized items cant be upgraded
	public virtual void Upgrade ()
	{
		Debug.Log("No property to upgrade.");
	}
	//Any item is disenchable if property allows
	public virtual Item Disenchant ()
	{
		if(disenchantable)return new Item("Dust");
		return null;
	}

	public string GetName ()
	{
		return name;
	}

	public bool Disenchantable ()
	{
		return disenchantable;
	}
}

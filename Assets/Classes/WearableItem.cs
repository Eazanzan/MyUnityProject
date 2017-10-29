using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearableItem : Item {
	protected int stat;
	protected int upgradeLevel;
	protected enum ItemSlot {Armor,Weapon};
	protected ItemSlot itemSlot;
	bool wearable=true;

	//Placeholder constructor
	public WearableItem (string name)
	{
	}

	//A constructor for a wearable item-maybe for cosmetics?
	public WearableItem(string name, bool disenchantable, bool upgradable) : base("Item")
	{
		base.name = name;
		base.disenchantable= disenchantable;
		base.upgradable= upgradable;
		this.upgradeLevel =1;
	}

	public override void Upgrade ()
	{
		if (upgradable) {
			stat = (int)(stat*0.8);
			upgradeLevel++;
		}
	}

	public bool isWearable ()
	{
		return wearable;
	}

	public int getItemSlot ()
	{
		return (int)itemSlot;
	}
}

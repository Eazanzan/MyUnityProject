using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : WearableItem {

	//Weappn Constructor
	public Weapon (string name, bool disenchantable, bool upgradable,int attackPower) : base("WearableItem")
	{
		base.name = name;
		base.disenchantable= disenchantable;
		base.upgradable= upgradable;
		base.stat= attackPower;
		base.itemSlot = ItemSlot.Weapon;
	}

	public int GetAttackPower ()
	{
		return stat;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : WearableItem {

	//Armor Constructor
	public Armor (string name, bool disenchantable, bool upgradable,int defence) : base("WearableItem")
	{
		base.name = name;
		base.disenchantable= disenchantable;
		base.upgradable= upgradable;
		this.stat = defence;
		this.upgradeLevel =1;
	}

}

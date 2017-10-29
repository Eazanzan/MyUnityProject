using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory  {
	private static ItemFactory instance=null;

	private ItemFactory (){}

	public static ItemFactory getInstance ()
	{
		if (instance == null) {
			instance = new ItemFactory();
		}
		return instance;
	}
	
	public Item CreateItem (string name, bool disenchantable, bool upgradable, int stat, int itemID)
	{
		if (itemID == 0) {
			return new Item (name);
		} else if (itemID == 1) {
			return new Item (name, disenchantable, upgradable);
		} else if (itemID == 2) {
			return new Weapon (name, disenchantable, upgradable, stat);
		} else if (itemID == 3) {
			return new Armor (name, disenchantable, upgradable, stat);
		} 
		return null;
	}
}

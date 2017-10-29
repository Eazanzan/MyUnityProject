using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WearableItemScript : MonoBehaviour {

	Sprite itemIcon;
	string itemName;
	int propertyStat;//Defense if armor, attack power if weapon.
	int primaryStat;
	enum Primary {Strenght, Agilty ,Intellect};
	int vitality;
	enum Rarity{Common,Uncommon,Rare,Epic, Legendary};
	public enum ItemSlot{Weapon,Armor};
	Primary stat;
	Rarity rar;
	ItemSlot slot;

	public bool disenchantable;
	bool upgradable;

	public void Initialize (string itemName,int propStat,int primary,int primaryVal,int vita,ItemSlot itemSlot,bool dis,bool upg,Sprite icon)
	{
		this.itemName = itemName;
		name = itemName;
		propertyStat = propStat;
		primaryStat=primaryVal;
		if(primary==1)stat = Primary.Strenght;
		else if(primary==2)stat = Primary.Agilty;
		else if(primary==3)stat = Primary.Intellect;
		vitality =vita;
		slot = itemSlot;
		disenchantable=dis;
		upgradable = upg;
		SetRarity();
		this.GetComponent<Image>().sprite =icon;
	}

	void SetRarity ()
	{
		//TODO:calculate rarity according to stats
		if (vitality == 0) {
			int avg = (propertyStat + primaryStat) / 2;
			if (avg < 20) {
				rar = Rarity.Common;
			} else if (avg < 40 && avg > 20) {
				rar = Rarity.Uncommon;
			} else if (avg < 60 && avg > 40) {
				rar = Rarity.Rare;
			} else if (avg < 80 && avg > 60) {
				rar = Rarity.Epic;
			} else {
				rar = Rarity.Legendary;
			}
		} else {
			int avg = (propertyStat + primaryStat+vitality) / 2;
			if (avg < 20) {
				rar = Rarity.Common;
			} else if (avg < 40 && avg > 20) {
				rar = Rarity.Uncommon;
			} else if (avg < 60 && avg > 40) {
				rar = Rarity.Rare;
			} else if (avg < 80 && avg > 60) {
				rar = Rarity.Epic;
			} else {
				rar = Rarity.Legendary;
			}
		}
	}

	public ItemSlot GetItemSlotType ()
	{
		return slot;
	}

	public bool Disenchantable ()
	{
		return disenchantable;
	}

	public bool Upgradable ()
	{
		return upgradable;
	}

	public void Upgrade(){
	 	primaryStat = (int)(primaryStat *1.1);
	 	propertyStat = (int)(propertyStat *1.1);
		vitality = (int)(vitality *1.1);
		SetRarity();
	}

	public Sprite getIcon ()
	{
		return GetComponent<Image>().sprite;
	}

	public string getName ()
	{
		return itemName;
	}

	public string getPrimary ()
	{
		return stat.ToString();
	}

	public int getPrimaryVal ()
	{
		return primaryStat;
	}

	public int getStatVal ()
	{
		return propertyStat;
	}

	public int getVitality ()
	{
		return vitality;
	}

	public string getRarity ()
	{
		return rar.ToString();
	}

	public string getSLot ()
	{
		return slot.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
    public LocalStates states = new LocalStates();
    public string name;
	public int id;
	public struct position
	{
		public float x;
		public float y;
	}
	public position pos;

	public struct CardData
	{
		public string name;
		public int health;
		public int attack;
		public int skill;
    };

	protected CardData GetCardData(int newid, bool isCharacter)
	{
		CardData data;
		data.name = "";
		data.health = -1;
		data.attack = -1;
		data.skill = -1;
		if (newid == Constants.CARD_CHAR_WARRIOR) {
			data.name = "Wojownik";
			data.health = 5;
			data.attack = 1;
			data.skill = Constants.SKILL_BLOCK;
		}
		else if (newid == Constants.CARD_CHAR_MAGE) {
			data.name = "Mag";
			data.health = 5;
			data.attack = 1;
			data.skill = Constants.SKILL_REDUCE;
		}
		else if (newid == Constants.CARD_CHAR_HEALER) {
			data.name = "Uzdrowiciel";
			data.health = 5;
			data.attack = 1;
			data.skill = Constants.SKILL_HEAL;
		}
		else if (newid == Constants.CARD_ITEM_HEAL) {
			data.name = "Mikstura uzdrawiająca";
			data.health = -1;
			data.attack = -1;
			data.skill = Constants.SKILL_HEAL;
		}
		else if (newid == Constants.CARD_ITEM_BLOCK) {
			data.name = "Bomba dymna";
			data.health = -1;
			data.attack = -1;
			data.skill = Constants.SKILL_BLOCK;
		}
		else if (newid == Constants.CARD_ITEM_REDUCE) {
			data.name = "Mikstura wytrzymałości";
			data.health = -1;
			data.attack = -1;
			data.skill = Constants.SKILL_REDUCE;
		}
		else if (newid == Constants.CARD_ITEM_RESURRECT) {
			data.name = "Zwój wskrzeszenia";
			data.health = -1;
			data.attack = -1;
			data.skill = Constants.SKILL_RESURRECT;
		}
		else if (newid == Constants.CARD_ITEM_BERSERK) {
			data.name = "Mikstura furii";
			data.health = -1;
			data.attack = -1;
			data.skill = Constants.SKILL_BERSERK;
		}
		return data;
	}
}

public class Character : Card {
	public int maxhealth;
	public int defattack;
	public int health;
	public int attack;
	public int skill;
    public bool blocked;
	public bool used;

	public Character(int newid, float posx, float posy)
	{
		CardData data = GetCardData (newid, true);
		id = newid;
		name = data.name;
		maxhealth = data.health;
		health = data.health;
		defattack = data.attack;
		attack = data.attack;
		skill = data.skill;
		blocked = false;
		used = false;
		pos.x = posx;
		pos.y = posy;
	}

	public void DoDamage(int dmg)
	{
		health -= dmg;
		if (health < 0)
			health = 0;
	}

	public void DoHeal(int dmg)
	{
		health += dmg;
		if (health > maxhealth)
			health = maxhealth;
	}
}

public class Item : Card {
	public int skill;

    public Item(int newid, float posx, float posy)
	{
		CardData data = GetCardData (newid, true);
		id = newid;
		name = data.name;
		skill = data.skill;
		pos.x = posx;
		pos.y = posy;
	}
}

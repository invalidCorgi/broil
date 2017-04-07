using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginHotseat : MonoBehaviour {

	public GameObject CharCardPrefab;
	public GameObject ItemCardPrefab;

	void PlaceCharCard(int Card, float posx, float posy)
	{
		GameObject CardObject = Instantiate(CharCardPrefab, new Vector3(posx, posy, 0), Quaternion.identity);
		CardObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Cards/"+Card.ToString());
		CardObject.GetComponent<CharacterCardInfo> ().CardInfo = new Character (Card, posx, posy);
	}

	void PlaceItemCard(int Card, float posx, float posy)
	{
		GameObject CardObject = Instantiate(ItemCardPrefab, new Vector3(posx, posy, 0), Quaternion.identity);
		CardObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Cards/"+Card.ToString());
		CardObject.GetComponent<ItemCardInfo>().CardInfo = new Item (Card, posx, posy);
	}

	int DrawCard(List<int> list)
	{
		int n = Random.Range (0, list.Count-1);
		int result = list [n];
		list.RemoveAt (n);
		return result;
	}

	// Draw cards from decks for both players
	void Start () {

		List<int> P1Characters = new List<int> ();
		P1Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P1Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P1Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P1Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P1Characters.Add (Constants.CARD_CHAR_MAGE);
		P1Characters.Add (Constants.CARD_CHAR_MAGE);
		P1Characters.Add (Constants.CARD_CHAR_MAGE);
		P1Characters.Add (Constants.CARD_CHAR_HEALER);
		P1Characters.Add (Constants.CARD_CHAR_HEALER);
		P1Characters.Add (Constants.CARD_CHAR_HEALER);

		List<int> P2Characters = new List<int> ();
		P2Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P2Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P2Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P2Characters.Add (Constants.CARD_CHAR_WARRIOR);
		P2Characters.Add (Constants.CARD_CHAR_MAGE);
		P2Characters.Add (Constants.CARD_CHAR_MAGE);
		P2Characters.Add (Constants.CARD_CHAR_MAGE);
		P2Characters.Add (Constants.CARD_CHAR_HEALER);
		P2Characters.Add (Constants.CARD_CHAR_HEALER);
		P2Characters.Add (Constants.CARD_CHAR_HEALER);

		List<int> P1Items = new List<int> ();
		P1Items.Add (Constants.CARD_ITEM_HEAL);
		P1Items.Add (Constants.CARD_ITEM_HEAL);
		P1Items.Add (Constants.CARD_ITEM_REDUCE);
		P1Items.Add (Constants.CARD_ITEM_REDUCE);
		P1Items.Add (Constants.CARD_ITEM_BLOCK);
		P1Items.Add (Constants.CARD_ITEM_BLOCK);
		P1Items.Add (Constants.CARD_ITEM_RESURRECT);
		P1Items.Add (Constants.CARD_ITEM_RESURRECT);
		P1Items.Add (Constants.CARD_ITEM_BERSERK);
		P1Items.Add (Constants.CARD_ITEM_BERSERK);

		List<int> P2Items = new List<int> ();
		P2Items.Add (Constants.CARD_ITEM_HEAL);
		P2Items.Add (Constants.CARD_ITEM_HEAL);
		P2Items.Add (Constants.CARD_ITEM_REDUCE);
		P2Items.Add (Constants.CARD_ITEM_REDUCE);
		P2Items.Add (Constants.CARD_ITEM_BLOCK);
		P2Items.Add (Constants.CARD_ITEM_BLOCK);
		P2Items.Add (Constants.CARD_ITEM_RESURRECT);
		P2Items.Add (Constants.CARD_ITEM_RESURRECT);
		P2Items.Add (Constants.CARD_ITEM_BERSERK);
		P2Items.Add (Constants.CARD_ITEM_BERSERK);

		int i;
		for (i = 0; i <= 2; i++) {
			PlaceCharCard (DrawCard (P2Characters), -2.2f + i * 2.2f, 1.5f);
			PlaceCharCard (DrawCard (P1Characters), -2.2f + i * 2.2f, -1.5f);
			PlaceItemCard (DrawCard (P2Items), -2.2f + i * 2.2f, 4f);
			PlaceItemCard (DrawCard (P1Items), -2.2f + i * 2.2f, -4f);
		}
	}
}

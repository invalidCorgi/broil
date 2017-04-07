using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CardEvents : MonoBehaviour
{
    const float nSize = 0.3f;
    const float sSize = 0.35f;
    const float zSize = 1f;

	void OnMouseEnter()
	{
        if (GlobalStates.isAnyCardZoomed == true) return;
		this.transform.localScale = new Vector3(sSize, sSize, this.transform.localScale.z);
		GetComponent<SpriteRenderer> ().sortingLayerName = "Displayed";
	}

	void OnMouseExit()
	{
        if (GlobalStates.isAnyCardZoomed == true) return;
        if (this.name == "CharacterCard(Clone)")
        {
            if (!this.GetComponent<CharacterCardInfo>().CardInfo.states.isSelected)
            {
                this.transform.localScale = new Vector3(nSize, nSize, this.transform.localScale.z);
                GetComponent<SpriteRenderer>().sortingLayerName = "Cards";
            }
        }
        else
        {
            if (!this.GetComponent<ItemCardInfo>().CardInfo.states.isSelected)
            {
                this.transform.localScale = new Vector3(nSize, nSize, this.transform.localScale.z);
                GetComponent<SpriteRenderer>().sortingLayerName = "Cards";
            }
        }
	}

	public const double MAX_TIME_TO_CLICK = 0.5;
	public const double MIN_TIME_TO_CLICK = 0.05;
	public bool IsDebug { get; set; }
	private TimeSpan maxDuration = TimeSpan.FromSeconds(MAX_TIME_TO_CLICK);
	private TimeSpan minDuration = TimeSpan.FromSeconds(MIN_TIME_TO_CLICK);
	private System.Diagnostics.Stopwatch timer;
	private bool ClickedOnce = false;

	public bool DoubleClick()
	{
		if (!ClickedOnce)
		{
			timer = System.Diagnostics.Stopwatch.StartNew();
			ClickedOnce = true;
		}
		if (ClickedOnce)
		{
			if (timer.Elapsed > minDuration && timer.Elapsed < maxDuration)
			{
				if (IsDebug)
					Debug.Log("Double Click");
				ClickedOnce = false;
				return true;
			}
			else if (timer.Elapsed > maxDuration)
			{
                timer = System.Diagnostics.Stopwatch.StartNew();
                if (IsDebug)
					Debug.Log("Time out");
				return false;
			}
		}
		return false;
	}

	void OnMouseDown()
	{
        if (this.name == "CharacterCard(Clone)")
        {
            if ( (this.GetComponent<CharacterCardInfo>().CardInfo.states.isSelected == false) && (GlobalStates.isAnyCardSelected == false) )
            {
                this.GetComponent<CharacterCardInfo>().CardInfo.states.isSelected = true;
                GlobalStates.isAnyCardSelected = true;
            }
            else
            {
                if(this.GetComponent<CharacterCardInfo>().CardInfo.states.isSelected == true)
                    GlobalStates.isAnyCardSelected = false;
                this.GetComponent<CharacterCardInfo>().CardInfo.states.isSelected = false;
            }
        }
        else
        {
            if ( (this.GetComponent<ItemCardInfo>().CardInfo.states.isSelected == false) && (GlobalStates.isAnyCardSelected == false) )
            {
                this.GetComponent<ItemCardInfo>().CardInfo.states.isSelected = true;
                GlobalStates.isAnyCardSelected = true;
            }
            else
            {
                if (this.GetComponent<ItemCardInfo>().CardInfo.states.isSelected == true)
                    GlobalStates.isAnyCardSelected = false;
                this.GetComponent<ItemCardInfo>().CardInfo.states.isSelected = false;
            }
        }

        if (DoubleClick()) {
            if (this.transform.localScale.x >= zSize) {
                this.transform.localScale = new Vector3(nSize, nSize, this.transform.localScale.z);
                if (this.name == "CharacterCard(Clone)") {
                    this.transform.position = new Vector3(GetComponent<CharacterCardInfo>().CardInfo.pos.x, GetComponent<CharacterCardInfo>().CardInfo.pos.y, this.transform.position.z);
                    if(GetComponent<CharacterCardInfo>().CardInfo.states.isSelected == true)
                        this.transform.localScale = new Vector3(sSize, sSize, this.transform.localScale.z);
                    GlobalStates.isAnyCardZoomed = false;
                }
                else {
                    this.transform.position = new Vector3(GetComponent<ItemCardInfo>().CardInfo.pos.x, GetComponent<ItemCardInfo>().CardInfo.pos.y, this.transform.position.z);
                    if (GetComponent<ItemCardInfo>().CardInfo.states.isSelected == true)
                        this.transform.localScale = new Vector3(sSize, sSize, this.transform.localScale.z);
                    GlobalStates.isAnyCardZoomed = false;
                }
                return;
            }

            if (GlobalStates.isAnyCardZoomed == false)
            {
                this.transform.localScale = new Vector3(zSize, zSize, this.transform.localScale.z);
                this.transform.position = new Vector3(0f, 0f, this.transform.position.z);
                GlobalStates.isAnyCardZoomed = true;
            }
		}
	}
}
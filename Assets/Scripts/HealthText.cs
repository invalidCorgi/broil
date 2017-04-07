using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().sortingLayerID = this.transform.parent.GetComponent<Renderer> ().sortingLayerID;
		GetComponent<TextMesh> ().text = this.transform.parent.GetComponent<CharacterCardInfo> ().CardInfo.health.ToString ();
	}
}

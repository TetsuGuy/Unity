using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of the Dialog-Pack
//Is used to further Dialog between 2 NPCs A and B 
//Attach it to 1 NPC and set the 2 Triggers
//When A is done with his/her dialog, B loads new Dialog 
//When B is done (after A was done), A loads new Dialog
//And so on, until no new dialog is available. 


public class DialogBackNForth : MonoBehaviour {

	public DialogTriggerOptionA_Human a;
	public DialogTriggerOptionA_Human b;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (a.isDone () && a.DialogSelector==b.DialogSelector) {
			b.nextDialog ();
		}
		if (b.isDone () && b.DialogSelector==a.DialogSelector+1) {
			a.nextDialog ();
		}
	}
}

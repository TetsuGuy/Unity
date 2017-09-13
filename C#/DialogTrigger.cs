using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of Dialog-Package (need all skripts)
//Attach it to your characters, talking objects, etc. 
//Specify/Set Dialog in Unity after attaching Skript

public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;
	public int pitch;
	public void TriggerDialogue(){
		FindObjectOfType<DialogBase> ().StartDialog (dialog,pitch);
	}

}

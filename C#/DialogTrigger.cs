using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;
	public int pitch;
	public void TriggerDialogue(){
		FindObjectOfType<DialogBase> ().StartDialog (dialog,pitch);
	}

}

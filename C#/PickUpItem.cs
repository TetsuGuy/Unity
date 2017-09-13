using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to any item that you can pickup
//Part of trigger-Dialog Package (not needed for dialog to work but doesnt work without dialogpack)
//if you dont want to message player, you can use it anyway. Just delete trigger.TriggerDialog() and 
//trigger Variable

public class PickUpItem : MonoBehaviour {
	
	public DialogTrigger trigger;
	public Item item;
	private bool done;
	// Use this for initialization
	void Start () {
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!done && Vector3.Distance (GameObject.Find("Player").transform.position, transform.position) < 0.5 && Input.GetMouseButtonDown(1)){
			done = true;
			trigger.TriggerDialogue ();
			GameObject.Find("Player").GetComponent<Inventory> ().addItem (item);
			Destroy(gameObject);
		}		
	}
}
	
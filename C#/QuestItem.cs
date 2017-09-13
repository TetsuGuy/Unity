using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

//Simple Quest-Item Type
//Set Number to the QuestNr it belongs
//Part of Quest-Package[Quest, QuestItem, QuestManager]

//is disabled while not every Quest inside [dependingOn] is fulfilled (if you dont want your questitem to depend just leave field empty after attaching)
//is attached to questitem
//set destroyable to true if the gameobject shouldnt remain.

	
	public DialogTrigger trigger;
	public bool done;
	public bool destroyable;
	public int questNr;
	public List<Quest> dependingOn; 

	// Use this for initialization
	void Start () {
		done = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (isPrepared () && !done && Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position) < 3	&& Input.GetMouseButtonDown (1)) 
		{
			done = true;
			trigger.TriggerDialogue ();
			GameObject.Find ("Player").GetComponent<QuestManager> ().addItem (questNr);
			if (destroyable) 
			{
				if (GameObject.Find ("Player").GetComponent<QuestManager> ().isDone (questNr)) 
				{
					gameObject.GetComponent<AudioSource> ().Play ();
					Destroy (gameObject, gameObject.GetComponent<AudioSource> ().clip.length);
				} 
				else
					Destroy (gameObject);
			} 
			else 
			{
				if (GameObject.Find ("Player").GetComponent<QuestManager> ().isDone (questNr)) 
				{
					gameObject.GetComponent<AudioSource> ().Play ();
					Destroy (gameObject, gameObject.GetComponent<AudioSource> ().clip.length);
				}		
			}
		}
	}

	public bool isPrepared(){
		bool prepared = true;
		if (dependingOn.Count > 0) {
			foreach (Quest q in dependingOn) {
				if (!q.done)
					prepared = false;
			}
		}
		return prepared;
	}
}

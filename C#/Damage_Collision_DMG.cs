using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Skript works together with the HealthSkript in the GitHub Repo. 
//It is used for collision-damage
//Example: The Player runs into a fire and takes damage
//Attach this skript to the fire-object and the health-skript to the player
//Note: the Player-Object must be called Player. Else you have to change line 29

public class Damage_Collision_DMG : MonoBehaviour {

	public int damage;
	public float cooldown;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision other){
		if (other.gameObject.tag=="Player" && Time.time-timer>cooldown) {
			timer = Time.time;
			GameObject.Find ("Player").GetComponent<HealthScript> ().changeHealth (-damage);
		}
	}
}

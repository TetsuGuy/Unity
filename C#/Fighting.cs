using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles fighting


//needs healthscript
//needs Stats.cs


//Explanation:
//Attach it to Player 
//If Player collides with EnemyHitbox, they enter a "fight"
//Reduces Enemys Health a specified amount (int damage) 
//damage is inflicted very x seconds (x= int cooldown)
//The Player is fighting if the user clicked the Left Mouse-Button (change accordingly to your preferences)


public class Fighting : MonoBehaviour {
	public int damage;
	public float cooldown;
	private float time;
	// Use this for initialization
	void Start () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnCollisionStay(Collision other){
		if (	other.gameObject.tag == "Enemy" 
				&& Input.GetMouseButton(0)
				&& Time.time-time>cooldown
			)
		{
			time = Time.time;
			if (other.gameObject.GetComponent<HealthScript> ().healthpoints - damage <= 0) {
				//then Enemy dies. Before that, give player experience 
				GameObject.Find("Player").GetComponent<Stats>().newExperience(other.gameObject.GetComponent<EnemyScript>().EXP);
			}
			other.gameObject.GetComponent<HealthScript> ().changeHealth (-damage);
		}
	}
}

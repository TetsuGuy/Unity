using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

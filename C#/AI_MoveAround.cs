using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_MoveAround : MonoBehaviour {
	public bool isActive;
	public Vector3 direction;
	public float speed;
	public float speedR;
	private Rigidbody rb;
	public float COOLDOWN_MAX;
	private float cooldown;
	private float time;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		isActive = true;
		time = Time.time;
		cooldown = COOLDOWN_MAX*Random.Range(0.5f,1.5f);
		direction = new Vector3 (Random.Range (-2, 2),0, Random.Range (-2, 2));
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			rb.AddForce (speed * direction, ForceMode.Impulse);

			Vector3 newDir = Vector3.RotateTowards (transform.forward, direction, speedR * Time.deltaTime, 0.0F);
			transform.rotation = Quaternion.LookRotation (newDir);

			if (Time.time - time > cooldown) {
				time = Time.time;
				cooldown = COOLDOWN_MAX * Random.Range (0.5f, 1.5f);
				direction = new Vector3 (Random.Range (-2, 2), 0, Random.Range (-2, 2));
			}
		}
	}
}

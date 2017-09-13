using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_AngerAndFollow : MonoBehaviour {
	//Distance to Object that is safe, if crossed, then anger + follow 
	public float dangerZone;
	public float speed;
	public float speedR;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position) < dangerZone) 
		{
			gameObject.GetComponent<AI_MoveAround> ().isActive = false;
			rb.AddForce (speed *transform.forward, ForceMode.Impulse);

			Vector3 newDir = Vector3.RotateTowards (transform.forward, GameObject.Find("Player").transform.position-transform.position, speedR * Time.deltaTime, 0.0F);
			transform.rotation = Quaternion.LookRotation (newDir);
		} 

		else {
			gameObject.GetComponent<AI_MoveAround> ().isActive = true;
		}
	}
}
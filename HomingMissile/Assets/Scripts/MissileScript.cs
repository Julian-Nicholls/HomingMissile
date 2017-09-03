using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour {

	public float launchForce;
	public float flightForce;
	public float rotationForce;

	float timeSinceLaunch;
	Rigidbody rb;

	float startHeight;
	bool homing = false;

	public GameObject target;

	// Use this for initialization
	void Start () {

		startHeight = transform.position.y;

		rb = GetComponent<Rigidbody> ();
		rb.AddForce (transform.up * launchForce);
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			Destroy (gameObject);
		}

		if (transform.position.y < startHeight) {
			homing = true;
		}

		if (homing) {
			//this is the money maker
			//and i have to thank the unity community for it
			//http://answers.unity3d.com/questions/161202/physics-based-homing-missile.html

			Vector3 targetDelta = target.transform.position - transform.position;

			float angleDelta = Vector3.Angle (transform.up, targetDelta);

			Vector3 crossProduct = Vector3.Cross (transform.up, targetDelta);

			rb.AddTorque (crossProduct * angleDelta * rotationForce);

			rb.AddForce (transform.up * flightForce();
		}
	}

	public void setTarget(GameObject t){
		target = t;
	}
}

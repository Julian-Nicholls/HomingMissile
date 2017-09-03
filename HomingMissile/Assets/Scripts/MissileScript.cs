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
	void FixedUpdate () {

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

			float dotProduct = Vector3.Dot (Vector3.up, rb.velocity);

			Vector3 targetDelta;

			if (dotProduct <= 0.5f) {
				targetDelta = (target.transform.position - rb.velocity) - transform.position;

			} else {
				targetDelta = (target.transform.position - rb.velocity/2) - transform.position;

			}



			float angleDelta = Vector3.Angle (transform.up, targetDelta);

			Vector3 crossProduct = Vector3.Cross (transform.up, targetDelta);

			rb.AddTorque (crossProduct * angleDelta * rotationForce);

			//-- and this is me so it's a little more convoluted

			//Vector3 direction = Vector3.Lerp (transform.up, rb.velocity.normalized, 0.5f);

			rb.AddForce(transform.up * flightForce);
		}
	}

	public void setTarget(GameObject t){
		target = t;
	}
}

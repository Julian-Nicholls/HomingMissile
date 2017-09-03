using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

	public GameObject prefab;
	public float spawnTime;
	public float launchForce;
	public float launchVariance;

	float timeSinceLastSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

		if (timeSinceLastSpawn > spawnTime) {

			timeSinceLastSpawn = 0;
			spawn (prefab);
		}
	}

	void spawn(GameObject prefab){
		
		GameObject target = Instantiate (prefab, this.transform.position, new Quaternion(), transform);
		Rigidbody rb = target.GetComponent<Rigidbody> ();

		rb.AddForce (Vector3.up * launchForce);
		rb.AddForce (
			new Vector3 (
				Random.Range (-launchVariance, launchVariance),
				Random.Range (-launchVariance, launchVariance),
				Random.Range (-launchVariance, launchVariance)));




	}
}

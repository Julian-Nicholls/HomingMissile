using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

	public GameObject prefab;
	public GameObject launcher;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Space)) {
			spawn (prefab);
		}
	}

	void spawn(GameObject prefab){

		GameObject missile = Instantiate (
	        prefab, 
	        launcher.transform.position, 
	        Quaternion.Euler (-55, 0, 0), 
	        transform);

		missile.GetComponent<MissileScript>().setTarget (GameObject.FindGameObjectsWithTag ("target") [0]);

	}
}

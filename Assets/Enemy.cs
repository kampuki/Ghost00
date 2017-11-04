using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject bullet;

	IEnumerator Start() {

		while (true) {

			Instantiate (bullet, transform.position, transform.rotation);

			yield return new WaitForSeconds (2.0f);
		}
	}

	
	
	// Update is called once per frame
	void Update () {
		
	}
}

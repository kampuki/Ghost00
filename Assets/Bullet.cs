﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 2.0f;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D> ().velocity = transform.right.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

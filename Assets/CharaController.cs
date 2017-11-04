using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour {

	private Rigidbody2D rigid2D;

	private float turnForce = 400.0f;

	// Use this for initialization
	void Start () {

		this.rigid2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			GetComponent<Animator> ().SetTrigger ("jumpTrigger");
		}

		if (Input.GetKeyDown(KeyCode.Space)) {

			rigid2D.AddForce (transform.up * 400);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			rigid2D.AddForce (new Vector2(-200, 0));
		
		} else if (Input.GetKeyDown(KeyCode.RightArrow)) {

			rigid2D.AddForce (new Vector2(200, 0));
				}
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Bullet") {

			SceneManager.LoadScene ("GameoverScene");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour {

	private Rigidbody2D rigid2D;

	private float turnForce = 400.0f;

	private Animator animator;

	// Use this for initialization
	void Start () {

		this.rigid2D = GetComponent<Rigidbody2D> ();

		this.animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			animator.SetTrigger ("attackTrigger");
		}

		if (Input.GetKeyDown(KeyCode.Space)) {

			rigid2D.AddForce (transform.up * 400);
		}

		if (Input.GetKey ("right")) {
			rigid2D.velocity = new Vector2 (1.0f, 0);
			animator.SetBool ("walkR", true);
		} else {
			animator.SetBool ("walkR", false);
		}

		if (Input.GetKey ("left")) {
			rigid2D.velocity = new Vector2 (-1.0f, 0);
			animator.SetBool ("walkL", true);
		} else {
			animator.SetBool ("walkL", false);
		}

	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Bullet") {

			SceneManager.LoadScene ("GameoverScene");
		}

		if (col.gameObject.tag == "Goal") {

			SceneManager.LoadScene ("GoalScene");
		}
	}
}

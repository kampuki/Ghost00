using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaController : MonoBehaviour {

	private Rigidbody2D rigid2D;

	private float turnForce = 400.0f;

	private Animator animator;

	public GameObject attackArea;

	public GameObject attackAreaL;

	private AudioSource audioSorce;

	public AudioClip attackSound;

	private bool isLButtonDown = false;

	private bool isRButtonDown = false;

	private bool isLAttackButtonDown = false;

	private bool isRAttackButtonDown = false;

	private bool isJumpButtonDown = false;

	// Use this for initialization
	void Start () {

		this.rigid2D = GetComponent<Rigidbody2D> ();

		this.animator = GetComponent<Animator> ();

		this.audioSorce = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightCommand) || this.isRAttackButtonDown) {

			Instantiate (attackArea, transform.position, transform.rotation);

			if (transform.localScale.x < 0)
				AdjustScale ();
			animator.SetTrigger ("attackTrigger");
			audioSorce.PlayOneShot (attackSound);
		}

		if (Input.GetKey (KeyCode.LeftCommand) || this.isLAttackButtonDown) {

			Instantiate (attackAreaL, transform.position, transform.rotation);

			if (transform.localScale.x > 0)
				AdjustScale ();
			animator.SetTrigger ("attackTriggerL");
			audioSorce.PlayOneShot (attackSound);
		}

		if (Input.GetKeyDown(KeyCode.Space) || this.isJumpButtonDown) {

			rigid2D.AddForce (transform.up * 400);
		}

		if (Input.GetKey ("right") || this.isRButtonDown) {
			rigid2D.velocity = new Vector2 (3.0f, 0);

			if(transform.localScale.x < 0) 
				AdjustScale ();
				animator.SetBool ("walkR", true);

		} else {
			animator.SetBool ("walkR", false);
		}

		if (Input.GetKey ("left") || this.isLButtonDown) {
			rigid2D.velocity = new Vector2 (-3.0f, 0);
				if(transform.localScale.x > 0) 
					AdjustScale ();
			animator.SetBool ("walkL", true);
		} else {
			animator.SetBool ("walkL", false);
		}

	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Bullet") {

			SceneManager.LoadScene ("GameoverScene");
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		
		if (col.gameObject.tag == "Goal") {

			SceneManager.LoadScene ("GoalScene");
		}
	}

	void AdjustScale () {

		transform.localScale = new Vector3 (transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
	}

	public void GetMyRightButtonDown () {

		this.isRButtonDown = true;
	}

	public void GetMyRightButtonUp () {

		this.isRButtonDown = false;
	}

	public void GetMyLeftButtonDown () {

		this.isLButtonDown = true;
	}

	public void GetMyLeftButtonUp () {

		this.isLButtonDown = false;
	}

	public void GetMyRightAttackButtonDown () {

		this.isRAttackButtonDown = true;
	}

	public void GetMyRightAttackButtonUp () {

		this.isRAttackButtonDown = false;
	}

	public void GetMyLeftAttackButtonDown () {

		this.isLAttackButtonDown = true;
	}

	public void GetLeftAttackButtonUp () {

		this.isLAttackButtonDown = false;
	}

	public void GetJumpButtonDown () {

		this.isJumpButtonDown = true;
	}

	public void GetJumpButtonUp () {

		this.isJumpButtonDown = false;
	}
}

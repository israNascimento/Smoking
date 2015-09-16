using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	const float TIME_TO_DIE = 180;
	float speed, currentTime;
	public bool canMove, isWalking, isSit;
	Animator animator;

	void Start () 
	{
		this.speed = 0.015f;
		this.canMove = true;
		this.isSit = false;
		this.animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		isWalking = false;
		currentTime += Time.deltaTime;
		if (currentTime > TIME_TO_DIE) 
		{
			this.canMove = false;
		}

		if (this.canMove) 
		{
			Movement ();
		}

		animator.SetBool ("isWalking", isWalking);
		animator.SetBool ("isSit", isSit);
	}

	void Movement()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Translate(-speed, 0, 0);
			this.transform.localScale = new Vector3(1, 1, 1);
			isWalking = true;
		}

		else if (Input.GetKey(KeyCode.RightArrow))
		{
			this.isWalking = true;
			this.transform.Translate(speed, 0, 0);
			this.transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag.Equals ("Interactable")) 
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				this.canMove = !this.canMove;
				this.isSit   = !this.isSit;
			}
		}
	}
}

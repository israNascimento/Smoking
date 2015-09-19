using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	const float TIME_TO_DIE = 180;
	float speed, currentTime;
	public bool canMove, isWalking, isSit, isDead, jaCriei;
	public static bool gameStart = false;
	Animator animator;

	FXManager fxManager;
	[SerializeField]
	GameObject instructionArrow, instructionUp, panel;

	void Start () 
	{
		this.speed = 0.015f;
		this.canMove = true;
		this.isSit = false;
        gameStart = false;
		this.animator = GetComponent<Animator> ();

		fxManager = GameObject.Find ("FXManager").GetComponent<FXManager> ();
		StartCoroutine (Instructions ());
		StartCoroutine (GameStart ());
	}

	void FixedUpdate()
	{
		if (!gameStart)
			return;

		isWalking = false;
		currentTime += Time.deltaTime;
		if (currentTime > TIME_TO_DIE) 
		{
			isDead = true;
		}

		if (this.canMove) 
		{
			Movement ();
		}

		animator.SetBool ("isWalking", isWalking);
		animator.SetBool ("isSit", isSit);

		if (isDead)
		{
			ChangeScene();
		}
	}

	void ChangeScene()
	{
		if(!jaCriei)
			fxManager.CreateFadeIn (panel, 0.005f, "Final");
		
		jaCriei = true;
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

        if(collider.gameObject.tag.Equals("Interactable"))
        {
			if(Input.GetKeyDown(KeyCode.UpArrow) && !Cigarette.isReloading)
			{
				this.canMove = !this.canMove;
				this.isSit   = !this.isSit;
			}
        }
		
	}

	IEnumerator Instructions()
	{
		yield return new WaitForSeconds (3);
		fxManager.CreateFadeOut (this.instructionArrow, 0.05f);
		fxManager.CreateFadeOut (this.instructionUp, 0.05f);
	}

	IEnumerator CreateFade()
	{
		yield return new WaitForSeconds (1);
		fxManager.CreateFadeIn (panel, 0.05f, "Final");
	}

	IEnumerator GameStart()
	{
		yield return new WaitForSeconds (22.5f);
		gameStart = true;
	}
}

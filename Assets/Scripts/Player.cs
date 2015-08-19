using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	float speed;
	bool canMove;

	void Start () 
	{
		this.speed = 0.03f;
		this.canMove = true;
	}

	void FixedUpdate()
	{
		if (this.canMove) {
			Movement ();
		}
	}

	void Movement()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Translate(-speed, 0, 0);
			this.transform.localScale = new Vector3(1, 1, 1);
		}

		else if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Translate(speed, 0, 0);
			this.transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	void ResizeSpriteToScreen() 
	{
		SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
		if (sr == null) return;
		
		transform.localScale = new Vector3(1,1,1);
		
		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;
		
		float worldScreenHeight = (float)(Camera.main.orthographicSize * 2.0);
		float worldScreenWidth = (float)worldScreenHeight / Screen.height * Screen.width;
		
		transform.localScale = new Vector3 (worldScreenWidth / width * 0.1f, worldScreenHeight / height *0.15f, 0.1f);
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag.Equals ("Interactable")) 
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
				this.canMove = !this.canMove;
			}
		}
	}
}

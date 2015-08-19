using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	float speed;

	void Start () 
	{
		this.speed = 0.05f;
	}

	void FixedUpdate()
	{
		Movement();
		ResizeSpriteToScreen ();
	}

	void Movement()
	{
		if (Input.GetKey(KeyCode.A))
		{
			this.transform.Translate(-speed, 0, 0);
			this.transform.localScale = new Vector3(-1, 1, 1);
		}

		else if (Input.GetKey(KeyCode.D))
		{
			this.transform.Translate(speed, 0, 0);
			this.transform.localScale = new Vector3(1, 1, 1);
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
		
		transform.localScale = new Vector3 (worldScreenWidth / width * 0.1f, worldScreenHeight / height, 0.1f);
	}
}

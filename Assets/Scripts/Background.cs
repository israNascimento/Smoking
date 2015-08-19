using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
	void Start () 
	{
		ResizeSpriteToScreen ();
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
		
		transform.localScale = new Vector3 (worldScreenWidth / width * 3, worldScreenHeight / height, 1);
	}
}

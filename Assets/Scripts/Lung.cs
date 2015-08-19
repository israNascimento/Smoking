using UnityEngine;
using System.Collections;

public class Lung : MonoBehaviour {

	enum LUNG
	{
		EASY,
		NORMAL,
		HARD,
		VERY_HARD,
		MUITO_DIFICIL
	}
	LUNG lung;
	[SerializeField]
	Sprite[] sprites;
	SpriteRenderer renderer;

	void Start ()
	{
		lung = LUNG.EASY;
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	void FixedUpdate () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			renderer.sprite = sprites [(int)++lung];
		}
	}
}

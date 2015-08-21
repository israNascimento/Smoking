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
	float time;

	void Start ()
	{
		lung = LUNG.EASY;
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	void FixedUpdate () 
	{
		if (MathManager.instance.GetTime(ref time, 60)) 
		{
			renderer.sprite = sprites [(int)++lung];
		}
	}
}

class MathManager
{

	private static MathManager mathManager;
	public static MathManager instance
	{

		get
        {
		    if(mathManager == null)
		    {
			    mathManager = new MathManager();
		    }
	
		    return mathManager;
        }
	}

	public bool GetTime(ref float currentTime, float time)
	{
		currentTime += Time.deltaTime;
		if (currentTime > time) {
			currentTime = 0;
			return true;
		}
		return false;
	}
}

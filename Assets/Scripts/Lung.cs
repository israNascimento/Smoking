using UnityEngine;
using System.Collections;

public class Lung : MonoBehaviour {

	enum LUNG
	{
		EASY,
		NORMAL,
		HARD
	}
	LUNG lung;

	[SerializeField]
	Sprite[] sprites;
	SpriteRenderer renderer;
	float time;
	int currentID;

	void Start ()
	{
		lung = LUNG.EASY;
		renderer = GetComponent<SpriteRenderer> ();
		currentID = 0;
	}
	
	void FixedUpdate () 
	{
		if (MathManager.instance.GetTime (ref time, 60) && currentID < 3) 
		{
			currentID++;
			renderer.sprite = sprites [currentID];
		} 
		else
		{
			currentID = 0;
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

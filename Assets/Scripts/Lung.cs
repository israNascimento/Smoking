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
	public Sprite badLung;
	SpriteRenderer renderer;
	float time;
	public int currentID;

	void Start ()
	{
		lung = LUNG.EASY;
		renderer = GetComponent<SpriteRenderer> ();
		currentID = 0;
	}


	void PlayerObject()
	{
		if (!Player.gameStart)
			return;
		if (MathManager.instance.GetTime (ref time, 40) && currentID < 4) 
		{
			currentID++;
			renderer.sprite = sprites [currentID];
		} 
	}

	public void NPC_Damage()
	{
		currentID++;
		renderer.sprite = sprites [currentID];
	}

	void NPC_Object()
	{
		if (this.currentID == 4)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = badLung;
		}
	}

	void FixedUpdate () 
	{
		if (this.gameObject.name.Equals("NPC"))
		{
			print (this.currentID);
		}
		switch(this.gameObject.transform.parent.name)
		{
		case "Character":
				PlayerObject();
			break;
		case "NPC":
				NPC_Object();
			break;
		default:
			PlayerObject();
			break;
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

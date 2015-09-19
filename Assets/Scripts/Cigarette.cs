using UnityEngine;
using System.Collections;

public class Cigarette : MonoBehaviour 
{
	float current;
	int numberOfCigarette;
	Animator anim;
	public static bool isReloading;

	[SerializeField]
	GameObject smokeGameObject;
	[SerializeField]
	Transform positionToInstance;

	Player p;
	void Start () 
	{
		p = GameObject.Find ("Character").GetComponent<Player> ();
		current = 25;
		anim = GetComponent<Animator> ();
		StartCoroutine (InstatiateSmoke ());
	}
	
	void FixedUpdate () 
	{
		current -= (1 * Time.deltaTime);
		if (current <= 0 && p.isSit == false) 
		{
			numberOfCigarette += 1;
			current = 25;
			p.canMove = false;
			isReloading = true;
			anim.SetBool("cigaretteEnd", true);
			StartCoroutine(changeCigarreteEnd());
		}
	}

	IEnumerator changeCigarreteEnd()
	{
		yield return new WaitForSeconds(1f);
		p.canMove  = true;
		anim.SetBool ("cigaretteEnd", false);
		isReloading = false;
	}

	IEnumerator InstatiateSmoke()
	{
		while (true) {
			yield return new WaitForSeconds(5);
			Instantiate(smokeGameObject, positionToInstance.position, Quaternion.identity);
		}
	}
}

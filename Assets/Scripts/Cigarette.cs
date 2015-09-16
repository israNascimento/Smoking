using UnityEngine;
using System.Collections;

public class Cigarette : MonoBehaviour 
{
	float current;
	int numberOfCigarette;
	Animator anim;
	bool isReloading;

	[SerializeField]
	GameObject smokeGameObject;
	[SerializeField]
	Transform positionToInstance;

	Player p;
	void Start () 
	{
		p = GameObject.Find ("Character").GetComponent<Player> ();
		current = 10;
		anim = GetComponent<Animator> ();
		StartCoroutine (InstatiateSmoke ());
	}
	
	void FixedUpdate () 
	{
		current -= (1 * Time.deltaTime);
		if (current <= 0 && p.isSit == false) 
		{
			numberOfCigarette += 1;
			current = 10;
			Debug.LogWarning("NOVO CIGARRO! NUMERO DE CIGARROS CONSUMIDOS: " +numberOfCigarette);
			p.canMove = false;
			isReloading = true;
			anim.SetBool("cigaretteEnd", true);
			StartCoroutine(changeCigarreteEnd());
		}
	}

	IEnumerator changeCigarreteEnd()
	{
		yield return new WaitForSeconds(1f);
		anim.SetBool ("cigaretteEnd", false);
			p.canMove  = true;
		isReloading = false;
	}

	IEnumerator InstatiateSmoke()
	{
		while (true) {
			yield return new WaitForSeconds(6);
			Instantiate(smokeGameObject, positionToInstance.position, Quaternion.identity);
		}
	}
}

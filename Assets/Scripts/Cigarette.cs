using UnityEngine;
using System.Collections;

public class Cigarette : MonoBehaviour 
{
	float current;
	int numberOfCigarette;
	Animator anim;
	void Start () 
	{
		current = 10;
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () 
	{
		current -= (1 * Time.deltaTime);
		if (current <= 0) 
		{
			numberOfCigarette += 1;
			current = 10;
			Debug.LogWarning("NOVO CIGARRO! NUMERO DE CIGARROS CONSUMIDOS: " +numberOfCigarette);
			anim.SetBool("cigaretteEnd", true);
			StartCoroutine(changeCigarreteEnd());
		}
	}

	IEnumerator changeCigarreteEnd()
	{
		yield return new WaitForSeconds(1f);
		anim.SetBool ("cigaretteEnd", false);
	}
}

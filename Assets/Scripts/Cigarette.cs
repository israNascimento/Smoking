using UnityEngine;
using System.Collections;

public class Cigarette : MonoBehaviour {

	float current;
	int numberOfCigarette;
	void Start () 
	{
		current = 10;
	}
	
	void FixedUpdate () 
	{
		current -= (1 * Time.deltaTime);
		if (current <= 0) 
		{
			numberOfCigarette += 1;
			current = 10;
			Debug.LogWarning("NOVO CIGARRO! NUMERO DE CIGARROS CONSUMIDOS: " +numberOfCigarette);
		}
	}
}

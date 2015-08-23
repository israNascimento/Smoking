using UnityEngine;
using System.Collections;

public class Cigarette : MonoBehaviour 
{
	float current;
	int numberOfCigarette;
    Animator anim;
    Player player;

	void Start () 
	{
		this.current = 10;
        anim = GetComponent<Animator>();
        this.player = GetComponent<Player>();
	}
	
	void FixedUpdate () 
	{
		current -= (1 * Time.deltaTime);
		if (current <= 0) 
		{
			numberOfCigarette += 1;
			current = 10;
            player.canMove = false;
            anim.SetBool("cigaretteEnd", true);
            StartCoroutine(isReloaded());
			Debug.LogWarning("NOVO CIGARRO! NUMERO DE CIGARROS CONSUMIDOS: " +numberOfCigarette);
        }
	}

    IEnumerator isReloaded()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("cigaretteEnd", false);
        player.canMove = true;
    }
}

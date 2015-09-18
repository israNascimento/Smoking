using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag.Equals("Smoke"))
		{
			this.gameObject.GetComponent<Lung>().NPC_Damage();
		}
	}
}

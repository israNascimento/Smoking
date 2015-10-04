using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D c)
	{
		if (this.gameObject.GetComponent<Lung>().currentID < 1)
		{
			if (c.gameObject.tag.Equals("Smoke"))
			{
				this.gameObject.GetComponent<Lung>().NPC_Damage();
				Destroy(c.gameObject);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour 
{
	GameObject player, bus;

	void Start()
	{
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.bus = GameObject.FindGameObjectWithTag ("Bus");
	}

	void FixedUpdate()
	{
		if (!this.player.GetComponent<Player> ().gameStart)
		{
			this.transform.position = new Vector3 (this.player.transform.position.x, this.transform.position.y, this.transform.position.z);
		}

		else if (this.player.transform.position.x > 0 && this.player.transform.position.x < 5)
		{
			this.transform.position = new Vector3 (this.player.transform.position.x, this.transform.position.y, this.transform.position.z);
		}
	}
}

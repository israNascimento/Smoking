using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour 
{
	public GameObject player, bus;
    Player p;

	void Start()
	{
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.bus = GameObject.FindGameObjectWithTag ("Bus");

        p = player.GetComponent<Player>();
	}

	void FixedUpdate()
	{
		if (!Player.gameStart)
		{
			this.transform.position = new Vector3 (this.bus.transform.position.x, this.transform.position.y, this.transform.position.z);
		}

		if (this.player.transform.position.x > 0 && this.player.transform.position.x < 5)
		{
			this.transform.position = new Vector3 (this.player.transform.position.x, this.transform.position.y, this.transform.position.z);
		}
	}
}

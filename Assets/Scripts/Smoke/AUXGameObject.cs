using UnityEngine;
using System.Collections;

public class AUXGameObject : MonoBehaviour {
	private float speedX, speedY;
	void Start () 
	{
		StartCoroutine (changeSpeed ());
	}
	
	void Update ()
	{
		this.gameObject.transform.position += new Vector3 (0.001f, speedY);
	}

	IEnumerator changeSpeed()
	{
		while (true) 
		{
			yield return new WaitForSeconds(1);
			Random r = new Random();
			//speedX = Random.Range(0.00001f, 0.002f);
			speedY = Random.Range(-0.002f, 0.002f);
		}
	}
}

using UnityEngine;
using System.Collections;

public class CloudManager : MonoBehaviour 
{
	int randNum, randCloud;
	Vector3 cloudPosition;
	public GameObject[] cloud;
	public GameObject layer;

	void Start()
	{
		StartCoroutine (spawn ());
	}

	void FixedUpdate()
	{
		this.randNum = Random.Range (15, 20);
		this.randCloud = Random.Range (0, 4);
		this.cloudPosition = new Vector3 (-1, Random.Range (-0.2f, 0.41f), 1);
		print (randCloud);
	}

	IEnumerator spawn()
	{
		while (true)
		{
			yield return new WaitForSeconds(this.randNum);
			Instantiate(cloud[this.randCloud], this.cloudPosition, Quaternion.identity);
		}
	}
}

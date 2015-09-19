using UnityEngine;
using System.Collections;

public class IAManager : MonoBehaviour {

	public GameObject[] iasGameObject;
	private float timeToInstance = 5;
	private float limitLeft;
	private float limitRight;

	void Start () 
	{
		StartCoroutine (InstanceIA ());
	}
	
	void Update () 
	{
		this.limitLeft  = GameObject.FindGameObjectWithTag ("LeftLimit").transform.position.x;
		this.limitRight = GameObject.FindGameObjectWithTag ("RightLimit").transform.position.x;
	}

	IEnumerator InstanceIA()
	{
		while (true) 
		{
			yield return new WaitForSeconds(this.timeToInstance);
			if(Random.Range(0f, 3f) > 1.5f)
			{
				Instantiate(iasGameObject[Random.Range(0, this.iasGameObject.Length)],
			            new Vector3(Random.Range(-8.87f, this.limitLeft), -1.57f), Quaternion.identity);
			}

			else
			{
				Instantiate(iasGameObject[Random.Range(0, this.iasGameObject.Length)],
				            new Vector3(Random.Range(this.limitRight, 24), -1.57f), Quaternion.identity);
			}

			this.timeToInstance -= 0.05f;

		}
	}
}

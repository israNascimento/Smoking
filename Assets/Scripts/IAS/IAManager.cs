using UnityEngine;
using System.Collections;

public class IAManager : MonoBehaviour {

	public GameObject[] iasGameObject;
	private int timeToInstance = 3;
	private float limitLeft;
	private float limitRight;

	void Start () 
	{
		StartCoroutine (InstanceIA ());
		this.limitLeft  = GameObject.FindGameObjectWithTag ("LeftLimit").transform.position.x;
		this.limitRight = GameObject.FindGameObjectWithTag ("RightLimit").transform.position.x;
	}
	
	void Update () 
	{
		
	}

	IEnumerator InstanceIA()
	{
		while (true) 
		{
			yield return new WaitForSeconds(this.timeToInstance);
		
				Instantiate(iasGameObject[Random.Range(0, this.iasGameObject.Length)],
				            new Vector3(Random.Range(-8, this.limitLeft), -1.57f), Quaternion.identity);

		}
	}
}

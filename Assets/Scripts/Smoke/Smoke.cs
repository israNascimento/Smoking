using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour 
{
	public GameObject rotation;
	void Start ()
	{

	}
	
	void Update () 
	{
		gameObject.transform.RotateAround (rotation.transform.position, Vector3.forward, 200 * Time.deltaTime);
	}
}

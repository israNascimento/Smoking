using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour 
{
	public GameObject rotation;
	TrailRenderer trail;
	
	void Start () 
	{
		this.trail = this.gameObject.GetComponent<TrailRenderer> ();
		trail.sortingLayerName = "Game";
		trail.sortingOrder = 10;	
	}
	
	void Update () 
	{
		gameObject.transform.RotateAround (rotation.transform.position, Vector3.forward, 200 * Time.deltaTime);//
	}
}
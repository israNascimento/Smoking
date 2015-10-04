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
		trail.sortingOrder = 19;	
	}
	
	void Update () 
	{
		gameObject.transform.RotateAround (rotation.transform.position, Vector3.forward, 100 * Time.deltaTime);//
	}
}
using UnityEngine;
using System.Collections;

public class provisional : MonoBehaviour 
{
	GameObject layer;

	void Start()
	{
		this.layer = GameObject.Find ("Layer");
		this.transform.parent = this.layer.transform;
	}
}

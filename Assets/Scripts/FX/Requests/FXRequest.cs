using UnityEngine;
using System.Collections;

public class FXRequest : MonoBehaviour 
{
	protected FXManager fxManager;
	protected GameObject target;

	void Start ()
	{
		this.target = this.gameObject;
		this.fxManager = GameObject.Find ("FXManager").GetComponent<FXManager> ();
		this.Request ();
	}

	protected virtual void Request(){}
}

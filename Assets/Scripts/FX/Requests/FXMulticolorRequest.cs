using UnityEngine;
using System.Collections;

public class FXMulticolorRequest : FXRequest 
{
	public float velocity;

	protected override void Request ()
	{
		base.Request ();
		this.fxManager.CreateMulticolor (this.target, this.velocity);
	}
}

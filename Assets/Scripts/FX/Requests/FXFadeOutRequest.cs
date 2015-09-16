using UnityEngine;
using System.Collections;

public class FXFadeOutRequest : FXRequest 
{
	public float velocity;

	protected override void Request ()
	{
		base.Request ();
		this.fxManager.CreateFadeOut (this.target, this.velocity);
	}
}

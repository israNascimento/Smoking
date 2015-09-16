using UnityEngine;
using System.Collections;

public class FXFadeInRequest : FXRequest 
{
	public string nextScene;
	public float velocity;

	protected override void Request ()
	{
		base.Request ();
		this.fxManager.CreateFadeIn (this.target, this.velocity, this.nextScene);
	}
}

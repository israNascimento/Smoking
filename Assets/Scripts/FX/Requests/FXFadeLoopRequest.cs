using UnityEngine;
using System.Collections;

public class FXFadeLoopRequest : FXRequest 
{
	public FXFadeLoop.States state;

	public float alpha_MIN;
	public float alpha_MAX;
	public float velocity;

	protected override void Request ()
	{
		base.Request ();
		this.fxManager.CreateFadeLoop (this.target, this.state, this.alpha_MIN, this.alpha_MAX, this.velocity);
	}
}

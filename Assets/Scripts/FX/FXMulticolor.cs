using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class FXMulticolor : FX
{
	#region Classes
	private Color color;
	#endregion
	#region Enums
	private enum Channels
	{
		NONE = 0,
		RED = 1,
		GREEN = 2,
		BLUE = 3
	}
	private enum OBJECTIVES
	{
		MIN,
		MAX
	}
	private Channels channel;
	private OBJECTIVES objective;
	#endregion
	#region Floats
	private float interference_MAX = 1;
	private float interference_MIN = 0.5f;
	private float interference = 1;
	private float velocity;
	#endregion
	#region Ints
	private int selector;
	#endregion

	public FXMulticolor(GameObject target, float velocity)
	{
		this.Target = target;

		this.objective = OBJECTIVES.MIN;

		this.velocity = velocity;

		this.ChooseChannel ();
	}

	public override void Update()
	{
		this.ChannelInterference ();
		this.ColorVerification ();
	}
	public override void ForcedDestroy()
	{
		
	}

	private void ChannelInterference()
	{
		if (this.objective == OBJECTIVES.MIN)
		{
			if (this.interference > this.interference_MIN)
				this.interference -= this.velocity;

			else
				this.objective = OBJECTIVES.MAX;
		}
		
		else
		{
			if (this.interference < this.interference_MAX)
				this.interference += this.velocity;
			
			else
			{
				this.objective = OBJECTIVES.MIN;
				this.ChooseChannel();
			}
		}
	}
	private void ChooseChannel()
	{
		this.selector = Operations.Random(0, Enum.GetNames(typeof(Channels)).Length);
		this.channel = (Channels)this.selector;
	}
	private void ColorVerification()
	{
		switch (this.channel)
		{
			case Channels.RED:
				this.color = new Color(this.interference, 1f, 1f, 1f);
				break;
			case Channels.GREEN:
				this.color = new Color(1f, this.interference, 1f, 1f);
				break;
			case Channels.BLUE:
				this.color = new Color(1f, 1f, this.interference, 1f);
				break;
		}

		try
		{
			this.Target.GetComponent<SpriteRenderer>().color = this.color;
		}

		catch{}

		try
		{
			this.Target.GetComponent<Image>().color = this.color;
		}

		catch{}

		try
		{
			this.Target.GetComponent<Text>().color = this.color;
		}

		catch{}
	}
}

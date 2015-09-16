using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class FXFade : FX
{
    #region Floats
    protected float alpha;
    protected float alpha_MIN;
    protected float alpha_MAX;
    protected float velocity;
    #endregion

    public override void Update() 
    {
        this.Fade();
        this.AlphaVerification();
    }
    public override void ForcedDestroy()
    {
        
    }

    protected void AlphaVerification()
    {
		Color color = new Color (1, 1, 1, this.alpha);

        try
        {
			this.Target.GetComponent<SpriteRenderer>().color = color;
        }

        catch { }

        try
        {
			this.Target.GetComponent<Image>().color = color;
        }

        catch { }

        try
        {
			this.Target.GetComponent<Text>().color = color;
        }

        catch { }
    }

    public abstract void Fade();
}

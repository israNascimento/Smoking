using UnityEngine;
using System.Collections;
    
public class FXFadeOut : FXFade 
{
    public FXFadeOut(GameObject target, float offset)
    {
        this.Target = target;
        this.Type = Types.FADE;
        this.alpha = 1;
        this.alpha_MIN = 0;
        this.velocity = offset;
    }

    public override void Fade()
    {
        if (this.alpha > this.alpha_MIN)
            this.alpha -= this.velocity;

        else
            this.DestroyTime();
    }
}

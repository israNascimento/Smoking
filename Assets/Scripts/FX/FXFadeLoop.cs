using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FXFadeLoop : FXFade
{
    #region Enums
    public enum States
    {
        FADEIN,
        FADEOUT
    }
    private States fade;
    #endregion

    public FXFadeLoop(GameObject target, States fade, float alpha_MIN, float alpha_MAX, float offset)
    {
        this.Target = target;
        this.fade = fade;
        this.Type = Types.FADE;
        this.alpha = (fade == FXFadeLoop.States.FADEIN) ? 0 : 1;
        this.alpha_MIN = alpha_MIN;
        this.alpha_MAX = alpha_MAX;
        this.velocity = offset;
    }
    public FXFadeLoop(GameObject target, States fade, float offset)
    {
        this.Target = target;
        this.Type = Types.FADE;
        this.fade = fade;
        this.alpha_MIN = 0;
        this.alpha_MAX = 1;
        this.velocity = offset;
    }

    public override void Fade()
    {
        if (this.fade == States.FADEIN)
        {
            if (this.alpha < this.alpha_MAX)
                this.alpha += this.velocity;

            else
                this.fade = States.FADEOUT;
        }

        else if (this.fade == States.FADEOUT)
        {
            if (this.alpha > this.alpha_MIN)
                this.alpha -= this.velocity;

            else
                this.fade = States.FADEIN;
        }
    }
}

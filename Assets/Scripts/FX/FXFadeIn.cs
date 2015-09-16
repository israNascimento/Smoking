using UnityEngine;
using System.Collections;

public class FXFadeIn : FXFade
{
    #region Strings
    private string nextScene = "";
    #endregion

    public FXFadeIn(GameObject target, float velocity)
    {
        this.Target = target;
        this.Type = Types.FADE;
        this.alpha = 0;
        this.alpha_MAX = 1;
        this.velocity = velocity;
    }
    public FXFadeIn(GameObject target, float velocity, string nextScene)
    {
        this.Target = target;
        this.Type = Types.FADE;
        this.nextScene = nextScene;
        this.alpha = 0;
        this.alpha_MAX = 1;
        this.velocity = velocity;
    }

    public override void Fade()
    {
		Debug.Log (this.alpha);

        if (this.alpha < this.alpha_MAX)
            this.alpha += this.velocity;

        else
        {
			Debug.Log(nextScene);

            if (!this.nextScene.Equals(""))
                Application.LoadLevel(this.nextScene);

            else
                this.DestroyTime();
        }
    }
}

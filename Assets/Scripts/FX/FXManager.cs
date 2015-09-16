using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FXManager : MonoBehaviour
{
    #region Lists
    private List<FX> fxs;
    #endregion
    #region Bools
    public bool earthquake;
    #endregion

    void Awake () 
    {
        this.fxs = new List<FX>();
	}
	void Update ()
    {
        foreach (FX fx in this.fxs)
        {
            if(fx.Target.activeSelf &&
              !fx.IsFinished)
                fx.Update();
        }

        this.GarbageCollector();
	}
	
    public void CreateEarthquake(GameObject target, FXEarthquake.Magnitudes magnitude, float range)
    {
        this.FXVerification(target, FX.Types.EARTHQUAKE);

        if (this.earthquake)
            this.fxs.Add(new FXEarthquake(target, magnitude, range));
    }
    public void CreateFadeLoop(GameObject target, FXFadeLoop.States fade, float alpha_MIN, float alpha_MAX, float offset)
    {
        this.FXVerification(target, FX.Types.FADE);
        this.fxs.Add(new FXFadeLoop(target, fade, alpha_MIN, alpha_MAX, offset));
    }
    public void CreateFadeLoop(GameObject target, FXFadeLoop.States fade, float offset)
    {
        this.FXVerification(target, FX.Types.FADE);
        this.fxs.Add(new FXFadeLoop(target, fade, offset));
    }
    public void CreateFadeOut(GameObject target, float offset)
    {
        this.FXVerification(target, FX.Types.FADE);
        this.fxs.Add(new FXFadeOut(target, offset));
    }
    public void CreateFadeIn(GameObject target, float offset)
    {
        this.FXVerification(target, FX.Types.FADE);
        this.fxs.Add(new FXFadeIn(target, offset));
    }
    public void CreateFadeIn(GameObject target, float offset, string nextScene)
    {
        this.FXVerification(target, FX.Types.FADE);
        this.fxs.Add(new FXFadeIn(target, offset, nextScene));
    }
    public void CreateLerp(GameObject target, Vector2 end, float time)
    {
        this.FXVerification(target, FX.Types.LERP);
        this.fxs.Add(new FXLerp(target, end, time));
    }
	public void CreateMulticolor(GameObject target, float velocity)
	{
		this.FXVerification(target, FX.Types.MULTICOLOR);
		this.fxs.Add(new FXMulticolor(target, velocity));
	}

    private void FXVerification(GameObject target, FX.Types type)
    {
        foreach (FX fx in this.fxs)
        {
            if (fx.Target == target &&
                fx.Type == type)
            {
                fx.ForcedDestroy();

                this.fxs.Remove(fx);

                break;
            }
        }
    }
    private void GarbageCollector()
    {
        foreach(FX fx in this.fxs)
        {
            if ((fx.DeltaTime != null &&
                 fx.DeltaTime.TimeIsOver("Destroy")))
            {
                this.fxs.Remove(fx);
                break;
            }
        }
    }

    public FX GetFX(GameObject target, FX.Types type)
    {
        foreach (FX fx in this.fxs)
        {
            if (fx.Target == target &&
                fx.Type == type)
                return fx;
        }

        return null;
    }
}

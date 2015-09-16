using UnityEngine;
using System.Collections;

public abstract class FX
{
    #region Classes
    public DeltaTime DeltaTime { get; set; }
    public GameObject Target { get; set; }
    #endregion
    #region Enums
    public enum Types
    {
        EARTHQUAKE,
        FADE,
        LERP,
		MULTICOLOR
    }
    public Types Type { get; set; }
    #endregion
    #region Bools
    public bool IsFinished { get; set; }
    #endregion

    protected void DestroyTime()
    {
        this.IsFinished = true;
        this.DeltaTime = new DeltaTime();
        this.DeltaTime.Create("Destroy", 2);
        this.DeltaTime.UpdateNext("Destroy");
    }

    public abstract void Update();
    public abstract void ForcedDestroy();
}

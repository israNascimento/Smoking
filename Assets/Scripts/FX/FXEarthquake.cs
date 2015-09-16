using UnityEngine;
using System.Collections;

public class FXEarthquake : FX
{
    #region Classes
    private Vector3 pivot;
    private Vector2 newPos;
    #endregion
    #region Enums
    public enum Magnitudes 
    { 
        LOW = 3,
        MEDIUM = 10, 
        HIGH = 15 
    };
    private Magnitudes magnitude;
    #endregion
    #region Floats
    private float range;
    #endregion
    #region Ints
    private int couter;
    #endregion

    public FXEarthquake(GameObject target, Magnitudes magnitude, float range)
    {
        this.Target = target;
        this.Type = Types.EARTHQUAKE;
        this.magnitude = magnitude;
        this.pivot = target.transform.position;
        this.range = range;
        this.couter = 0;
    }

    public override void Update()
    {
        this.Earthquake();
    }
    public override void ForcedDestroy()
    {
        this.Target.transform.position = this.pivot;
    }

    private void Earthquake()
    {
        Vector2 newPos = new Vector2(Random.Range(-this.range, this.range),
                                     Random.Range(-this.range, this.range));

        this.Target.transform.position = new Vector3((this.pivot.x + newPos.x),
                                                    (this.pivot.y + newPos.y),
                                                     this.pivot.z);
        this.couter++;

        if (this.couter >= (int)this.magnitude)
        {
            this.Target.transform.position = this.pivot;
            this.DestroyTime();
        }
    }
}

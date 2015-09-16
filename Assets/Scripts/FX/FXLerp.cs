using UnityEngine;
using System.Collections;
        
public class FXLerp : FX
{
    #region Classes
    private Vector2 end;
    #endregion
    #region Enums
    public enum Movements
    {
        HORIZONTAL,
        VERTICAL,
        DIAGONAL
    }
    private Movements movement;
    #endregion
    #region Floats
    private float distance_MIN = 10;
    private float time;
    #endregion

    public FXLerp(GameObject target, Vector2 end, float time)
    {
        this.Target = target;
        this.Type = FX.Types.LERP;
        this.end = end;
        this.time = time;

        if (end.x == target.transform.localPosition.x &&
            end.y == target.transform.localPosition.y)
            this.movement = Movements.DIAGONAL;

        else if (end.x == target.transform.localPosition.x)
            this.movement = Movements.VERTICAL;

        else if (end.y == target.transform.localPosition.y)
            this.movement = Movements.HORIZONTAL;
    }

    public override void Update()
    {
        this.Lerp();
    }
    public override void ForcedDestroy()
    {

    }

    public void Lerp()
    {
        if (!this.EndReached())
            this.Target.transform.localPosition = Vector3.Lerp(this.Target.transform.localPosition, this.end, this.time);

        else
        {
            this.Target.transform.localPosition = this.end;
            this.DestroyTime();
        }
    }

    private bool EndReached()
    {
        float distance_X = Operations.Module(Operations.Distance(this.Target.transform.localPosition.x,this.end.x));
        float distance_Y = Operations.Module(Operations.Distance(this.Target.transform.localPosition.y,this.end.y));

        switch (this.movement)
        {
            case Movements.HORIZONTAL:
                if (distance_X > distance_MIN)
                    return false;
                break;

            case Movements.VERTICAL:
                if (distance_Y > distance_MIN)
                    return false;
                break;

            case Movements.DIAGONAL:
                if (distance_X > distance_MIN &&
                    distance_Y > distance_MIN)
                    return false;
                break;
        }

        return true;
    }
}

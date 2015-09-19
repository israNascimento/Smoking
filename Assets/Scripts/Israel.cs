using UnityEngine;
using System.Collections;

public class Israel : MonoBehaviour
{
    private float speed;
    private string direction;
	void Start () 
	{
        speed = 0.01f;
        if (Random.Range(0, 2) > 3)
        {
            direction = "Right";
        }
        else
            direction = "Left";
	}
	
	void FixedUpdate() 
	{
        switch (direction)
        {
            case "Right":
                this.transform.Translate(speed, 0, 0);
                this.transform.localScale = new Vector3(-1, 1, 1);
                break;
            case "Left":
                this.transform.Translate(-speed, 0, 0);
                this.transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                this.transform.Translate(-speed, 0, 0);
                this.transform.localScale = new Vector3(1, 1, 1);
                break;
        }
	}
}

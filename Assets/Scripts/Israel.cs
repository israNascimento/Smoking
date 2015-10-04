using UnityEngine;
using System.Collections;

public class Israel : MonoBehaviour
{
    public float speed;
    private string direction;
	void Start () 
	{
       
        if (Random.Range(0, 6) > 3)
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

    void OnTriggerEnter2D(Collider2D c)
	{
        if (c.gameObject.name.Equals("MapLimit"))
        {
            if (direction == "Right")
                direction = "Left";
            else
                direction = "Right";
        }
	}
}

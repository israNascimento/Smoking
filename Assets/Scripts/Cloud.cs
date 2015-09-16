using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
	void FixedUpdate()
	{
		this.transform.Translate (0.001f, 0, 0);
	}
}

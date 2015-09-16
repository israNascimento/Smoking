using UnityEngine;
using System.Collections;

public class ParallaxOptions : MonoBehaviour
{
	public bool moveParallax;
	
	[SerializeField]
	[HideInInspector]
	Vector3 storedPosition;
	
	public void SavePosition() {
		storedPosition = transform.position;
	}
	
	public void RestorePosition() {
		transform.position = storedPosition;
	}
}
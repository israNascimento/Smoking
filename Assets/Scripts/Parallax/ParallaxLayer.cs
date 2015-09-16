using UnityEngine;
using System.Collections;

public class ParallaxLayer : MonoBehaviour 
{
	public float speedX;
	public float speedY;
	public bool moveInOppositeDirection;
	
	Transform cameraTransform;
	Vector3 previousCameraPosition;
	bool previousMoveParallax;
	ParallaxOptions options;
	
	void OnEnable() 
	{
		GameObject gameCamera = GameObject.Find("Main Camera");
		options = gameCamera.GetComponent<ParallaxOptions>();
		cameraTransform = gameCamera.transform;
		previousCameraPosition = cameraTransform.position;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			speedX = -0.2f;
		}
		else if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			speedX = 0.3f;
		}
		if(options.moveParallax && !previousMoveParallax)
			previousCameraPosition = cameraTransform.position;
		
		previousMoveParallax = options.moveParallax;
		
		if(!Application.isPlaying && !options.moveParallax)
			return;
		
		Vector3 distance = cameraTransform.position - previousCameraPosition;
		float direction = (moveInOppositeDirection) ? -1f : 1f;
		transform.position += Vector3.Scale(distance, new Vector3(speedX, speedY)) * direction;
		
		previousCameraPosition = cameraTransform.position;
	}
}

using UnityEngine;
using System.Collections;

public class ParallaxGenerator : MonoBehaviour
{
	public float maxMovement = 0.03F;
	public float offsetX = 0;
	public float offsetY = 0;
	public float strength = 0.3F;
	
	public Renderer parallaxRenderer;

	// Use this for initialization
	void Start ()
	{
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		calculateParallax ();
	
		parallaxRenderer.material.SetFloat ("_DirectionX", offsetX);
		parallaxRenderer.material.SetFloat ("_DirectionY", offsetY);
	}

	void calculateParallax ()
	{
		offsetX -= Input.gyro.rotationRateUnbiased.y * Time.deltaTime * strength;
		offsetY += Input.gyro.rotationRateUnbiased.x * Time.deltaTime * strength;
		
		if (Input.touchCount == 1) {
			offsetX = 0;
			offsetY = 0;
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			offsetX += Time.deltaTime * strength * 0.5f;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			offsetX -= Time.deltaTime * strength * 0.5f;
		}
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			offsetY += Time.deltaTime * strength * 0.5f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			offsetY -= Time.deltaTime * strength * 0.5f;
		}
		
		if (offsetX > maxMovement) {
			offsetX = maxMovement;
		}
		if (offsetX < maxMovement / 2) {
			offsetX = maxMovement / 2;
		}
		if (offsetY > maxMovement) {
			offsetY = maxMovement;
		}
		if (offsetY < maxMovement / 2) {
			offsetY = maxMovement / 2;
		}
		
	}
}

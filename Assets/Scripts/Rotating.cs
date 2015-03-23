using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour
{

	public float rotationSpeed = 30f;
	public float rotation = 0f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		rotation += rotationSpeed * Time.deltaTime;
		Vector3 euler = transform.localEulerAngles;
		euler.z = rotation;
		transform.localEulerAngles = euler;
	}
}

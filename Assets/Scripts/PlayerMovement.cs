using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public Controls controls;
	public float Speed = 3;
	
	public void Start ()
	{
		controls = FindObjectOfType<Controls> ();
	}
	
	public void Update ()
	{
		if (controls.Left) {
			MoveLeft ();
		}
		if (controls.Right) {
			MoveRight ();
		}
		
		if (transform.position.y < -7) {
			transform.position = new Vector3 (transform.position.x, 7, transform.position.z);
		}
	}
	
	public void MoveRight ()
	{
		GetComponent<Rigidbody2D> ().transform.Translate (Speed * Time.deltaTime, 0, 0);
	}
	
	public void MoveLeft ()
	{
		GetComponent<Rigidbody2D> ().transform.Translate (-Speed * Time.deltaTime, 0, 0);
	}
					
}
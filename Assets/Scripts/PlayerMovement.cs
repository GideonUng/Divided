using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 3;
	
	public void Start ()
	{
	}
	
	public void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			MoveLeft ();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			MoveRight ();
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
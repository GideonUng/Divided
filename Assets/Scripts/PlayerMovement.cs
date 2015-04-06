using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 3;
	private Rigidbody2D body;
	public Collider2D collider;
	
	public void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
	}
	
	public void Update ()
	{
		bool moving = false;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			MoveLeft ();
			moving = true;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			MoveRight ();
			moving = true;
		}
//		if (moving) {
//			collider.sharedMaterial.friction = 0;
//		} else {
//			collider.sharedMaterial.friction = 15;
//		}
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
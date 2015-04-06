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
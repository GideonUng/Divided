using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float Speed = 3;

	public GameObject PlayerWhite;
	public GameObject PlayerBlack;

	private bool moving;
	private Vector3 targetPos;
	private bool blockedLeft;
	private bool blockedRight;

	void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			MoveLeft();
		}
		if (Input.GetKey(KeyCode.D))
		{
			MoveRight();
		}
	}

	public void collidedLeft()
	{
		if (moving)
		{
			blockedLeft = true;
		}
	}

	public void collidedRight()
	{
		if (moving)
		{
			blockedRight = true;
		}
	}

	public void unblockedRight()
	{
		blockedRight = false;
	}

	public void unblockedLeft()
	{
		blockedLeft = false;
	}

	public void MoveRight()
	{
		GetComponent<Rigidbody2D>().transform.Translate(Speed * Time.deltaTime, 0, 0);
	}

	public void MoveLeft()
	{
		GetComponent<Rigidbody2D>().transform.Translate(-Speed * Time.deltaTime, 0, 0);
	}

	public void StopWalking()
	{
		GetComponent<Animator>().SetBool("Walking", false);
		moving = false;
	}
}
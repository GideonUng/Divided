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
		Debug.Log("MoveLeft");
		
		if (!blockedRight)
		{

		}
	}

	public void MoveLeft()
	{

	}

	public void StopWalking()
	{
		GetComponent<Animator>().SetBool("Walking", false);
		moving = false;
	}
}
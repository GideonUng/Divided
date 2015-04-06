using UnityEngine;
using System.Collections;

public class PlayerWorldSwitcher : MonoBehaviour
{

	public Collider2D whiteCollider;
	public Collider2D blackCollider;

	public void Switch (bool white)
	{
		if (white) {
			whiteCollider.enabled = true;
			blackCollider.enabled = false;
		} else {
			whiteCollider.enabled = false;
			blackCollider.enabled = true;
		}
	}

}

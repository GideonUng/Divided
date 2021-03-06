﻿using UnityEngine;
using System.Collections;

public class PlayerWorldSwitcher : MonoBehaviour
{

	public Collider2D whiteCollider;
	public Collider2D blackCollider;
	
	public void Start ()
	{
		Switch (true);
	}

	public void Switch (bool white)
	{
		if (whiteCollider == null || blackCollider == null) {
			return;
		}
	
		if (white) {
			whiteCollider.enabled = true;
			blackCollider.enabled = false;
		} else {
			whiteCollider.enabled = false;
			blackCollider.enabled = true;
		}
	}

}

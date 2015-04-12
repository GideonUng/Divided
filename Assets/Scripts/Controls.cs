using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{

	private bool right, left, switchValue;
	
	public bool Right { 
		get {
			return right || Input.GetKey (KeyCode.RightArrow);
		}
		set {
			right = value;
		}
	}

	public bool Left { 
		get {
			return left || Input.GetKey (KeyCode.LeftArrow);
		}
		set {
			left = value;
		}
	}
	
	public bool Switch { 
		get {
			return switchValue || Input.GetKeyDown (KeyCode.Space);
		}
		set {
			switchValue = value;
		}
	}
	
}

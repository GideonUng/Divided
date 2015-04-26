using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{

	private bool right, left;
	private bool switchValue = true;
	
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
			if(Input.GetKeyDown (KeyCode.Space)){
				switchValue = !switchValue;
			}
			return switchValue;
		}
		set {
			switchValue = value;
		}
	}
	
}

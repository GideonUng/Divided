using UnityEngine;
using System.Collections;

public class MenuAnimation : MonoBehaviour
{

	public Animator[] buttonAnimators;
	
	public void Start ()
	{
		buttonAnimators = GetComponentsInChildren<Animator> ();
	}

	public void showButton (int button)
	{
		button++;
//		Debug.Log ("Showing button " + buttonAnimators [button].gameObject.name);
		buttonAnimators [button].Play ("Show");
	}
	
	public void hideButton (int button)
	{
		button++;
//		Debug.Log ("Hiding button " + buttonAnimators [button].gameObject.name);
		buttonAnimators [button].Play ("Hide");
	}
}

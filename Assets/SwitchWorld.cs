using UnityEngine;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{
	public Camera CameraWhite;
	public Camera CameraBlack;
	public bool white = true;

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Space)) {
			if (white) {
				CameraWhite.enabled = false;
				CameraBlack.enabled = true;
				white = false;
			} else {
				CameraWhite.enabled = true;
				CameraBlack.enabled = false;
				white = true;
			}
		}
	}
}
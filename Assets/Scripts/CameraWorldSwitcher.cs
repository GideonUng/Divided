using UnityEngine;
using System.Collections;

public class CameraWorldSwitcher : MonoBehaviour
{
	public Camera CameraWhite;
	public Camera CameraBlack;

	public void Switch (bool white)
	{
		if (white) {
			CameraWhite.enabled = true;
			CameraBlack.enabled = false;
		} else {
			CameraWhite.enabled = false;
			CameraBlack.enabled = true;
		}
	}
}
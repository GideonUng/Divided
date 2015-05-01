using UnityEngine;
using System.Collections;

public class CameraWorldSwitcher : MonoBehaviour
{
	public Camera CameraWhite;
	public Camera CameraBlack;

	public void Switch (bool white)
	{
		if (CameraWhite == null || CameraBlack == null) {
			return;
		}
	
		if (white) {
			//CameraWhite.enabled = true;
			//CameraBlack.enabled = false;

			CameraWhite.cullingMask = (1 << 0) + (1 << 8) + (1 << 10) + (1 << 12);
			CameraBlack.cullingMask = (1 << 0) + (1 << 9) + (1 << 11);

			CameraWhite.depth = 0;
			CameraBlack.depth = -1;
		} else {
			//	CameraWhite.enabled = false;
			//	CameraBlack.enabled = true;

			CameraWhite.cullingMask = (1 << 0) + (1 << 8) + (1 << 10);
			CameraBlack.cullingMask = (1 << 0) + (1 << 9) + (1 << 11) + (1 << 12);

			CameraWhite.depth = -1;
			CameraBlack.depth = 0;
		}
	}
}
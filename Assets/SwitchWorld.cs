using UnityEngine;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{
	public Camera CameraWhite;
	public Camera CameraBlack;

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (CameraBlack.depth == 1)
			{
				CameraBlack.depth = 0;
				CameraWhite.depth = 1;
			}
			else if (CameraWhite.depth == 1)
			{
				CameraBlack.depth = 1;
				CameraWhite.depth = 0;
			}
		}
	}
}
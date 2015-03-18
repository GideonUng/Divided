using UnityEngine;
using System.Collections;

public class Restarter
{
	public static void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
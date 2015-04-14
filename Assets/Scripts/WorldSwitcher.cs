using UnityEngine;
using System.Collections;

public class WorldSwitcher : MonoBehaviour
{

	public bool white = true;
	private CameraWorldSwitcher[] camSwitchers;
	private	PlayerWorldSwitcher[] playerSwitchers;
	public Controls controls;
	
	void Start ()
	{
		controls = FindObjectOfType<Controls> ();
		camSwitchers = (CameraWorldSwitcher[])FindObjectsOfType (typeof(CameraWorldSwitcher));
		playerSwitchers = (PlayerWorldSwitcher[])FindObjectsOfType (typeof(PlayerWorldSwitcher));
	}
	
	void Update ()
	{
		if (controls.Switch) {
			white = !white;
			foreach (CameraWorldSwitcher switcher in camSwitchers) {
				switcher.Switch (white);
			}
			foreach (PlayerWorldSwitcher switcher in playerSwitchers) {
				switcher.Switch (white);
			}
		}
	}
}

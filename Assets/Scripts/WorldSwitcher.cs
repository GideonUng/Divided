using UnityEngine;
using System.Collections;

public class WorldSwitcher : MonoBehaviour
{

	public bool white = true;
	private CameraWorldSwitcher[] camSwitchers;
	private	PlayerWorldSwitcher[] playerSwitchers;

	// Use this for initialization
	void Start ()
	{
		camSwitchers = (CameraWorldSwitcher[])FindObjectsOfType (typeof(CameraWorldSwitcher));
		playerSwitchers = (PlayerWorldSwitcher[])FindObjectsOfType (typeof(PlayerWorldSwitcher));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Space)) {
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

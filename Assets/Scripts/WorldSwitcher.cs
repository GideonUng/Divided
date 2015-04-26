using UnityEngine;
using System.Collections;

public class WorldSwitcher : MonoBehaviour
{

	public bool white = true;
	private CameraWorldSwitcher[] camSwitchers;
	private	PlayerWorldSwitcher[] playerSwitchers;
	public Controls controls;
	private Camera whiteCamera;
	private Camera blackCamera;
	
	void Start ()
	{
		controls = FindObjectOfType<Controls> ();
		camSwitchers = (CameraWorldSwitcher[])FindObjectsOfType (typeof(CameraWorldSwitcher));
		playerSwitchers = (PlayerWorldSwitcher[])FindObjectsOfType (typeof(PlayerWorldSwitcher));
		whiteCamera = GameObject.Find ("CameraWhite").GetComponent<Camera> ();
		blackCamera = GameObject.Find ("CameraBlack").GetComponent<Camera> ();
	}
	
	void Update ()
	{
		if (controls.Switch != white) {
			white = !white;
			foreach (CameraWorldSwitcher switcher in camSwitchers) {
				switcher.Switch (white);
			}
			foreach (PlayerWorldSwitcher switcher in playerSwitchers) {
				switcher.Switch (white);
			}
		}
	}

	public Camera getActiveCamera ()
	{
		if (white) {
			return whiteCamera;
		} else {
			return blackCamera;
		}
	}

	public Camera getInactiveCamera ()
	{
		if (!white) {
			return whiteCamera;
		} else {
			return blackCamera;
		}
	}

}

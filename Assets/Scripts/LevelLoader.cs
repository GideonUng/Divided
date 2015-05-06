using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	public int level = 1;
	public GameObject cameraRig;
	public GameObject worldSwitcher;

	private Object levelInstance;
	private Object cameraRigInstance;
	private Object worldSwitcherInstance;
	
	private Controls controls;

	Controls ControlsInstance {
		get {
			if (controls != null) {
				return controls;
			} else {
				return controls = FindObjectOfType<Controls> ();
			}
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		setupLevel ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void restartLevel ()
	{		
		tearDownLevel ();
		setupLevel ();
	}
	
	public void tearDownLevel ()
	{
		if (worldSwitcherInstance != null) {
			Destroy (worldSwitcherInstance);
			worldSwitcherInstance = null;
		}
		if (cameraRigInstance != null) {
			Destroy (cameraRigInstance);
			cameraRigInstance = null;
		}
		if (levelInstance != null) {
			Destroy (levelInstance);
			levelInstance = null;
		}
	}

	public void setupLevel ()
	{
		levelInstance = Instantiate (Resources.Load (string.Format ("Levels/Level{0:00}", level), typeof(GameObject)), transform.position, transform.rotation);
		cameraRigInstance = Instantiate (cameraRig, transform.position, transform.rotation);
		worldSwitcherInstance = Instantiate (worldSwitcher, transform.position, transform.rotation);
		
		if (ControlsInstance != null) {
			ControlsInstance.Switch = true;
		}
	}
	
	public void nextLevel ()
	{
		level++;
		restartLevel ();
	}
}

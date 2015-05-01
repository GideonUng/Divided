using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	public GameObject level;
	public GameObject cameraRig;
	public GameObject worldSwitcher;

	public GameObject player;
	public Vector2 playerOffset;
	
	private Object levelInstance;
	private Object cameraRigInstance;
	private Object worldSwitcherInstance;
	private Object playerInstance;
	
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
		if (playerInstance != null) {
			Destroy (playerInstance);
			playerInstance = null;
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
		levelInstance = Instantiate (level, transform.position, transform.rotation);
		cameraRigInstance = Instantiate (cameraRig, transform.position, transform.rotation);
		playerInstance = Instantiate (player, new Vector3 (transform.position.x + playerOffset.x, transform.position.y + playerOffset.y, transform.position.z), transform.rotation);
		worldSwitcherInstance = Instantiate (worldSwitcher, transform.position, transform.rotation);
		
		if (ControlsInstance != null) {
			ControlsInstance.Switch = true;
		}
	}
}

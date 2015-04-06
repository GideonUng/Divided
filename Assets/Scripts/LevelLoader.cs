using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	public GameObject level;
	public GameObject cameraRig;
	public GameObject worldSwitcher;

	public GameObject player;
	public Vector2 playerOffset;
	
	// Use this for initialization
	void Start ()
	{
		Instantiate (level, transform.position, transform.rotation);
		Instantiate (cameraRig, transform.position, transform.rotation);
		Instantiate (player, new Vector3 (transform.position.x + playerOffset.x, transform.position.y + playerOffset.y, transform.position.z), transform.rotation);
		Instantiate (worldSwitcher, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

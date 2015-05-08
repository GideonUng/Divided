using UnityEngine;
using System.Collections;

public class Soulstone : MonoBehaviour
{
	private LevelLoader levelLoader;

	// Use this for initialization
	void Start ()
	{
		levelLoader = FindObjectOfType<LevelLoader> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.tag == "Player" && levelLoader != null) {
			levelLoader.nextLevel ();
			levelLoader = null;
		}
	}
}

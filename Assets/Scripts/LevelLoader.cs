using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	public GameObject prefab;

	// Use this for initialization
	void Start ()
	{
		Instantiate (prefab, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

using UnityEngine;
using System.Collections;

public class PrefabLoader : MonoBehaviour
{

	public string prefabName;

	void Start ()
	{
		GameObject soulstone = Instantiate (Resources.Load (prefabName, typeof(GameObject))) as GameObject;
		soulstone.transform.parent = transform.parent;
		soulstone.transform.localPosition = transform.localPosition;
		Destroy (this);
	}
}

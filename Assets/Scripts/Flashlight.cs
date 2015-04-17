using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{
	private MeshRenderer meshRenderer;
	private Vector2 flashLightPos;
	private SkinnedMeshRenderer skinnedRenderer;
	private WorldSwitcher worldSwitcher;

	void Start()
	{
		meshRenderer = gameObject.GetComponent<MeshRenderer>();
		worldSwitcher = FindObjectOfType<WorldSwitcher> ();
	}

	void Update()
	{
		if (Input.touchCount == 2)
		{
			Vector2 flashlightPos = ((Input.GetTouch(0).position + Input.GetTouch(1).position) / 2 / Screen.width * 100);

			skinnedRenderer.SetBlendShapeWeight(0, ((Input.touches[0].position - Input.touches[1].position).magnitude) / Screen.width * 100);
			skinnedRenderer.SetBlendShapeWeight(1, flashlightPos.x);
			skinnedRenderer.SetBlendShapeWeight(2, flashlightPos.y);
		}
		else if (Input.GetMouseButton(1))
		{
			meshRenderer.enabled = true;

			var current = worldSwitcher.getActiveCamera();
			var vector3 = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0f);
			Vector3 screenPosition = current.ScreenToWorldPoint (vector3);
			transform.position = new Vector3(screenPosition.x, screenPosition.y, transform.position.z);
		}
		else
		{
			meshRenderer.enabled = false;
		}
	}
}
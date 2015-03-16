using UnityEditor;
using UnityEngine;

public class PoligonEditor : EditorWindow
{
	string myString = "Hello World";
	bool groupEnabled;
	bool myBool = true;
	float myFloat = 1.23f;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/My Window")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(PoligonEditor));
	}

	void OnGUI()
	{
		GameObject a = Selection.activeGameObject;
		
		foreach (Vector3 v in a.GetComponent<PolygonCollider2D>().GetPath(0))
		{
			GUILayout.TextArea(v.ToString());
		}
		
		if (GUILayout.Button("Apply"))
		{
			a.GetComponent<PolygonCollider2D>().SetPath(0, new[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) });
		}

	}
}


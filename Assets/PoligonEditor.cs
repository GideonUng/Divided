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
		PolygonCollider2D a = Selection.activeGameObject.GetComponent<PolygonCollider2D>();

		if (a != null)
		{
			Vector2[] vS = new Vector2[a.GetPath(0).Length];
			if (GUILayout.Button("Round"))
			{
				int i = 0;
				foreach (Vector2 v in a.GetPath(0))
				{
					vS[i] = new Vector2(Mathf.CeilToInt(v.x), Mathf.Round(v.y));
					i++;
				}
				a.SetPath(0, vS);
			}

			foreach (Vector2 v in a.GetPath(0))
			{
				GUILayout.TextArea(v.ToString());
			}

			if (GUILayout.Button("Apply"))
			{
				a.SetPath(0, new[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) });
			}
		}
	}
}


using UnityEditor;
using UnityEngine;

public class PoligonEditor : EditorWindow
{
	int digits = 100;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/My Window")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(PoligonEditor));
	}

	void OnGUI()
	{
		if (Selection.activeGameObject.GetComponent<PolygonCollider2D>() ?? null)
		{
			PolygonCollider2D a = Selection.activeGameObject.GetComponent<PolygonCollider2D>();

			Vector2[] vS = new Vector2[a.GetPath(0).Length];
			if (GUILayout.Button("Round"))
			{
				int i = 0;
				foreach (Vector2 v in a.GetPath(0))
				{
					vS[i] = new Vector2(Mathf.Round(v.x * digits) / digits, Mathf.Round(v.y * digits) / digits);
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


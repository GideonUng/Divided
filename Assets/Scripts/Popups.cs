using UnityEngine;
using System.Collections;

public class Popups : MonoBehaviour
{

	public void openPopup (string actionName, string text, PopupAction popupAction)
	{
		Debug.Log ("Opening popup");
	
		GameObject popupLoader = new GameObject ();
		popupLoader.name = "PopupLoader";
			
		Popup popup = popupLoader.AddComponent<Popup> ();
		popup.popupAction = popupAction;
		popup.actionName = actionName;
		popup.text = text;
		popup.popupPanel = Resources.Load ("PopupContainer") as GameObject;
		
	}
	
	public void openRestartPopup ()
	{
		openPopup ("Restart", "Do you want to <color=\"#ff1643\">restart</color> this level?", delegate {
			LevelLoader levelLoader = FindObjectOfType (typeof(LevelLoader)) as LevelLoader;
			levelLoader.restartLevel ();
		});
	}

	public void openSkipPopup ()
	{
		openPopup ("Skip", "Do you want to <color=\"#ff1643\">skip</color> this level?", delegate {
			LevelLoader levelLoader = FindObjectOfType (typeof(LevelLoader)) as LevelLoader;
			levelLoader.nextLevel ();
		});
	}
	
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{

	public GameObject popupPanel;

	public string text;
	public string actionName;
	
	// Use this for initialization
	void Start ()
	{
		GameObject popups = GameObject.Find ("Popups");
		GameObject popup = Instantiate (popupPanel) as GameObject;
		popup.transform.SetParent (popups.transform, false);
		SetText ("ActionText", actionName.ToUpper ());
		SetText ("QuestionText", text);
	}
	
	void SetText (string textName, string text)
	{
		GameObject textGameObject = GameObject.Find (textName);
		Text textComponent = textGameObject.GetComponent<Text> ();
		textComponent.text = text;
	}
}

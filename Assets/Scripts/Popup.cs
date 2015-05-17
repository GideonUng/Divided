using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

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
		
		SetAction ("ActionButton", delegate() {
			Debug.Log ("Action pressed!");
		});
		SetAction ("CancelButton", delegate() {
			Debug.Log ("Cancel pressed!");
			Destroy (popup);
			Destroy (this.gameObject);
		});
	}

	void SetAction (string buttonName, UnityAction action)
	{
		GameObject buttonGameObject = GameObject.Find (buttonName);
		Button buttonComponent = buttonGameObject.GetComponent<Button> ();
		
		buttonComponent.onClick.AddListener (action);
		
	}
	
	void SetText (string textName, string text)
	{
		GameObject textGameObject = GameObject.Find (textName);
		Text textComponent = textGameObject.GetComponent<Text> ();
		textComponent.text = text;
		
		Debug.Log ("Set " + textName + " to " + text);
	}
}

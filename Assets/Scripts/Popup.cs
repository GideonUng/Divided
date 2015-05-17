using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public delegate void PopupAction ();

public class Popup : MonoBehaviour
{

	public GameObject popupPanel;

	public string text;
	public string actionName;
	
	public PopupAction popupAction;

	private GameObject popup;
	
	// Use this for initialization
	public	void Start ()
	{
		GameObject popups = GameObject.Find ("Popups");
		
		purgeChildren (popups);
		
		popup = Instantiate (popupPanel) as GameObject;
		popup.transform.SetParent (popups.transform, false);
		
		SetText ("ActionText", actionName.ToUpper ());
		SetText ("QuestionText", text);
		
		SetAction ("ActionButton", delegate() {
			Debug.Log ("Action pressed!");
			popupAction ();
			closePopup ();
		});
		SetAction ("CancelButton", delegate() {
			Debug.Log ("Cancel pressed!");
			closePopup ();
		});
	}
	
	private void closePopup ()
	{
		Animator animator = popup.GetComponent<Animator> ();
		animator.Play ("HidePopup");
		//Destroy (popup);
		Destroy (this.gameObject);
	}

	private void SetAction (string buttonName, UnityAction action)
	{
		GameObject buttonGameObject = GameObject.Find (buttonName);
		Button buttonComponent = buttonGameObject.GetComponent<Button> ();
		
		buttonComponent.onClick.AddListener (action);
		
	}
	
	private void SetText (string textName, string text)
	{
		GameObject textGameObject = GameObject.Find (textName);
		Text textComponent = textGameObject.GetComponent<Text> ();
		textComponent.text = text;
		
		Debug.Log ("Set " + textName + " to " + text);
	}

	void purgeChildren (GameObject popups)
	{
		foreach (Transform childTransform in popups.transform) {
			Destroy (childTransform.gameObject);
		}
	}
}

using System;
using UnityEngine.UI;
using UnityEngine;

public class ControlButton : Selectable
{ 
	public string controlProperty;
	
	private Controls controls;
	
	protected override void Start ()
	{
		base.Start ();
		controls = FindObjectOfType<Controls> ();
	}
	
	public override void OnPointerDown (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerDown (eventData);
		controls.GetType ().GetProperty (controlProperty).SetValue (controls, true, null);
	}
	
	public override void OnPointerUp (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		controls.GetType ().GetProperty (controlProperty).SetValue (controls, false, null);
	}
	
}

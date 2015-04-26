using System;
using UnityEngine.UI;
using UnityEngine;

public class ToggleButton : Selectable
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
		var prop = controls.GetType ().GetProperty (controlProperty);
		prop.SetValue (controls, !((bool)prop.GetValue(controls,null)), null);
	}

}

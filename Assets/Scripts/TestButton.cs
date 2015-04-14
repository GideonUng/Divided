using System;
using UnityEngine.UI;
using UnityEngine;

public class TestButton : Selectable
{
	private Controls controls;

	protected override void Start ()
	{
		base.Start ();
		controls = FindObjectOfType<Controls> ();
	}

	public override void OnPointerDown (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerDown (eventData);
		controls.Right = true;
	}

	public override void OnPointerUp (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		controls.Right = false;
	}

}


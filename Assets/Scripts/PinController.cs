using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{

	private bool active;

	void Start ()
	{
		active = true;
	}

	void Update ()
	{
		if (transform.up.y < 0.6f && active) {
			PlayerController.AddCount ();
			active = false;
		}
	}
}
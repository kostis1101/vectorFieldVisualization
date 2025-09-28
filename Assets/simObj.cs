using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class simObj : MonoBehaviour
{

	Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	public void change_position()
	{
		transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
		transform.position += new Vector3(0, 0, 10);
	}
}

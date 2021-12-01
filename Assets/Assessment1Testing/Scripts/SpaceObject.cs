using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
	public Camera cam;
	public float screenTop, screenBotton, screenLeft, screenRight;
	public Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		cam = Camera.main;
		Vector2 screenBottomLeft = cam.ScreenToWorldPoint(Vector2.zero);
		screenBotton = screenBottomLeft.y;
		screenLeft = screenBottomLeft.x;
		Vector2 screenTopRight = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		screenTop = screenTopRight.y;
		screenRight = screenTopRight.x;
	}

	// Update is called once per frame
    protected virtual void Update()
    {
	    if(transform.position.x > screenRight)
	    {
		    transform.position = new Vector2(screenLeft, transform.position.y);
	    }
	    if(transform.position.x < screenLeft)
	    {
		    transform.position = new Vector2(screenRight, transform.position.y);
	    }
	    if(transform.position.y > screenTop)
	    {
		    transform.position = new Vector2(transform.position.x, screenBotton);
	    }
	    if(transform.position.y < screenBotton)
	    {
		    transform.position = new Vector2(transform.position.x, screenTop);
	    }
    }
}

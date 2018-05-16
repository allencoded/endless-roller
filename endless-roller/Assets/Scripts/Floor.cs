using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.GetComponent<BallController>() != null) 
		{
			GameControl.instance.Scored();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

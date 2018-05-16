using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb2d;

	private FloorPool floorScript;

	// Use this for initialization
	void Start() 
	{
		GameObject gameController = GameObject.Find("GameController");
		floorScript = gameController.GetComponent<FloorPool>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() 
	{
		print(SystemInfo.deviceType);

		// maybe in future allow ball to adjust spawn right now though its wonky
		// if (transform.position.y < -1.3) 
		// {
		// 	floorScript.spawnRate = 0.8f;
		// } 
		// else 
		// {
		// 	floorScript.spawnRate = 2f;
		// }
	}

	void FixedUpdate()
	{
		if (SystemInfo.deviceType == DeviceType.Desktop)
		{
			DesktopControls();
		}
		
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			MobileControls();
		}
	}

	void DesktopControls() 
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0f);
		rb2d.AddForce(movement * speed);
	}

	void MobileControls() 
	{
		Vector2 movement = new Vector2 (Input.acceleration.x, 0f);
		rb2d.AddForce(movement * speed * 4);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPool : MonoBehaviour {
	public GameObject floorPrefab;
	public int floorPoolSize = 6;
	public float spawnRate = 2f;
	public float floorMin = -2.1f;
	public float floorMax = 2.1f;

	private GameObject[] floors;
	private int currentFloor = 0;

	private Vector2 objectPoolPos = new Vector2(-50, -5.4f);
	private float spawnYPos = -5.2f;
	
	private float timeSinceLastSpawned;

	private bool isFirstRun = true;

	// Use this for initialization
	void Start () 
	{
		timeSinceLastSpawned = 0f;

		floors = new GameObject[floorPoolSize];

		for (int i = 0; i < floorPoolSize; i++) 
		{
			floors[i] = (GameObject)Instantiate(floorPrefab, objectPoolPos, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastSpawned += Time.deltaTime;

		if ((GameControl.instance.gameOver == false && timeSinceLastSpawned > spawnRate) || isFirstRun)
		{
			isFirstRun = false;
			timeSinceLastSpawned = 0f;

			// randomize the (x) spawn pos
			float spawnXPos = Random.Range(floorMin, floorMax);

			floors[currentFloor].transform.position = new Vector2(spawnXPos, spawnYPos);

			currentFloor ++;

			if (currentFloor >= floorPoolSize) 
			{
				currentFloor = 0;
			}
		}
	}
}

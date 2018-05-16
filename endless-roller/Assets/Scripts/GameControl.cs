using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public static GameControl instance;
	public GameObject gameOverText;
	public bool gameOver = false;
	public float scrollSpeed = 2f;
	private int score = 0;
	public Text scoreText;

	void Awake () {
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this) 
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameOver && (Input.GetKeyDown("space") || Input.touchCount > 0))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void Scored() 
	{
		if (gameOver) 
		{
			return;
		}

		switch (score)
		{
			case 10:
				print("Increasing Speed");
				scrollSpeed = 2.0f;
				break;
			case 25:
				print("Increasing Speed");
				scrollSpeed = 2.2f;
				break;
			case 50:
				print("Increasing Speed");
				scrollSpeed = 2.5f;
				break;
			case 100:
				print("Increasing Speed");
				scrollSpeed = 3f;
				break;
			default:
				break;
		}
		score++;
		scoreText.text = "Score: " + score.ToString();
	}

	public void Died() 
	{
		print("GAME OVER");
		gameOver = true;
		gameOverText.SetActive(true);
	}
}

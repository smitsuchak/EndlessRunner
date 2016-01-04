using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	float timeRemaining = 10;
	float timeExtension = 3f;
	float timeDeduction = 2f;
	float totalTimeElapsed = 0;
	float score=0f;
	public bool isGameOver = false;

	public Text scoreTextHUD;
	public Text timeLeftTextHUD;
	public GameObject gameOverPanel;
	public Text gameOverScoreText;

	void Start(){
		Time.timeScale = 1;  // set the time scale to 1, to start the game world. This is needed if you restart the game from the game over menu
	}

	void Update () { 
		if (isGameOver) {
			if (!gameOverPanel.activeSelf) {
				showGameOverPanel();
			}
			return;
		}

		totalTimeElapsed += Time.deltaTime;
		score = totalTimeElapsed*100;
		timeRemaining -= Time.deltaTime;
		if(timeRemaining <= 0){
			isGameOver = true;
		}

		updateHUD ();

	}

	void updateHUD(){
	
		scoreTextHUD.text = "Score: " + (int)score;
		timeLeftTextHUD.text = "Time Left: " + (int)timeRemaining;
	}

	void showGameOverPanel(){
		gameOverPanel.gameObject.SetActive (true);
		Time.timeScale = 0;
		gameOverScoreText.text = "Score: " + (int)score;
	}

	public void PowerupCollected()
	{
		timeRemaining += timeExtension;
	}

	public void AlcoholCollected()
	{
		//Debug.LogError ("Inside Alcohol Collected " +timeDeduction);
		timeRemaining -= timeDeduction;
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu(){
		Application.LoadLevel(1);
	}

	public void Exit (){
		Application.Quit();
	}

}

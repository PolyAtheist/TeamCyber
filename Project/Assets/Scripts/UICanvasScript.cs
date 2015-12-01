using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICanvasScript : MonoBehaviour {
	
	public int timerSecondsLeft;
	//Value in which the timer will count down from
	public int timerTotalTime = 300;
	public int scoreBoardPlayerScore = 0;
	public int scoreBoardEnemyScore = 0;
	public bool nodeInfoVisible = false;
	public bool unitInfoVisible = false;
	
	int startTime;
	
	Text scoreBoardPlayerText;
	Text scoreBoardEnemyText;
	Text timerText;
	RectTransform nodeInfoPanel;
	RectTransform unitInfoPanel;
	//TODO Change this to be a list of unit scrpits
	//ArrayList<MonoBehaviour> nodeInfoUnitList;
	
	void Start () {
		//Get refernces to the child components needed
		scoreBoardPlayerText = GameObject.Find("PlayerScoreText").GetComponent<Text>();
		scoreBoardEnemyText = GameObject.Find("EnemyScoreText").GetComponent<Text>();
		timerText = GameObject.Find("TimerText").GetComponent<Text>();
		nodeInfoPanel = GameObject.Find("NodeInfoPanel").GetComponent<RectTransform>();
		unitInfoPanel = GameObject.Find("UnitInfoPanel").GetComponent<RectTransform>();
		
		//Set the start time to the current time in seconds
		startTime = (int)System.DateTime.Now.TimeOfDay.TotalSeconds;
		//Start the timer
		timerSecondsLeft = timerTotalTime;
	}
	
	void Update () {
		UpdateTimerTick ();
		UpdateScoreBoard();
		UpdateInfoPanels();
	}
	
	void UpdateTimerTick() {
		//Calculate how many seconds are left based on how many seconds have passed
		if(timerSecondsLeft > 0) {
			timerSecondsLeft = timerTotalTime - ((int)System.DateTime.Now.TimeOfDay.TotalSeconds - startTime);
		}
		
		int minutesLeft = timerSecondsLeft / 60;
		int secondsLeft = timerSecondsLeft % 60;
		//Update the text object on the timer panel
		timerText.text = minutesLeft.ToString("D2")+":"+secondsLeft.ToString("D2");
	}
	
	void UpdateScoreBoard() {
		//Update the text objects on the scoreboard
		scoreBoardPlayerText.text = scoreBoardPlayerScore.ToString();
		scoreBoardEnemyText.text = scoreBoardEnemyScore.ToString();
	}

	void UpdateInfoPanels() {
		Vector2 pos = nodeInfoPanel.anchoredPosition;
		//Move the panel onto or off of the screen based on nodeInfoVisible
		if(nodeInfoVisible) {
			nodeInfoPanel.anchoredPosition = new Vector2(-103.5f, pos.y);
		}
		else {
			nodeInfoPanel.anchoredPosition = new Vector2(103.5f, pos.y);
		}

		pos = unitInfoPanel.anchoredPosition;
		//Move the panel onto or off of the screen based on unitInfoVisible
		if(unitInfoVisible) {
			unitInfoPanel.anchoredPosition = new Vector2(193f, pos.y);
		}
		else {
			unitInfoPanel.anchoredPosition = new Vector2(-193f, pos.y);
		}

		DisplayUnitSelectors();
	}

	void DisplayUnitSelectors() {

	}
}

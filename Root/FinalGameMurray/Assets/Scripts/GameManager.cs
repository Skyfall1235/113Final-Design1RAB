//////////////////////////////////////////////////////
// Assignment/Lab/Project: FinalGame
//Name: Wyatt Murray
//Section: 2022FA.SGD.113.2173
//Instructor: Brian Sowers
// Date: 11/30/22
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public ScriptableObjectCreation playerInfo;
    [SerializeField] int level;
    [SerializeField] float localTime;
    [SerializeField] float globalTime;
    [SerializeField] private string displayLeveltime;


    public int[] potions = new int[3] { 0, 0, 0 };
    [SerializeField] private int health = 100;
    public int coins = 0;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject youWinPanel;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI timeText;
    

    [SerializeField] private bool allowInput;
    bool timerAllowed = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInfo.currentLevel = playerInfo.currentLevel + 1;
    }

    // Update is called once per frame
    void Update()
    {
        health = Player.GetComponent<BallPlayerController>().health;
        if(timerAllowed == true)
        {
            KeepLocalTime();
            KeepGlobalTime(playerInfo.currentLevel);
        }
        timeText.text = displayLeveltime;
        ChangeColorOfText();
    }

    #region timekeeping
    int minutes = 0;
    
    void KeepLocalTime()
    {
        int seconds = (int)localTime;
        localTime = localTime + Time.deltaTime;
        globalTime = globalTime + Time.deltaTime;

        
        //if thers s60 seconds passed, increment the minute and restart
        if (localTime >= 60)
        {
            localTime = 0;
            minutes++;
        }
        displayLeveltime = $"{minutes}m, {seconds}s";

    }
    string ConvertIntTimeToString(int inputAmountOfSeconds)
    {
        int minutes;
        int seconds;

        seconds = inputAmountOfSeconds % 60;
        minutes = seconds / 60;


        return $"{minutes}m, {seconds}s";
    }
    void KeepGlobalTime(int currentLevel)
    {
        //playerInfo.level1 +level2 +level3 time
        //diplay time
    }

    #endregion
    #region Crucial Functions

    public void SaveData(int currentLevel)
    {
        playerInfo.currentLevel = health;
        playerInfo.currentLevel = currentLevel;
        if(currentLevel == 1)
        {
            playerInfo.levelOneTime = globalTime; 
        }
        else if(currentLevel == 2)
        {
            playerInfo.levelTwoTime = globalTime;
        }
        else if(currentLevel == 3)
        {
            playerInfo.levelThreeTime = globalTime;
        }


        playerInfo.totalTime = playerInfo.levelOneTime + playerInfo.levelTwoTime + playerInfo.levelThreeTime;
    }
    public void Restart()
    {
        //set potions counts to 0
        //reload level
    }
    private void OnApplicationQuit()
    {
        playerInfo.levelOneTime = 0;
        playerInfo.levelTwoTime = 0;
        playerInfo.levelThreeTime = 0;
        playerInfo.totalTime = 0;
        playerInfo.deaths = 0;
        playerInfo.currentLevel = 0;
    }
    public void UpdateData(int hp)
    {
        coinText.text = ($"Player HP: {hp}\n Coins Collected:{coins}");
    }
    #endregion

    void ChangeColorOfText()
    {
        //SETS THE COLOR TO Red as requested when all coins in scene are picked up
        if (coins >= 10)
        {
            timeText.color = Color.red;
            timerAllowed = false;
        }
        
    }
    
    public void ShiftScene(int _levelArrayIdx)
    {
        //simple shift scene functiuon that moves scenes based on the parameter
        string[] levels = new string[] { "MainMenu", "DesignLevelOne", "DesignLevelTwo", "WinScene" };
        SceneManager.LoadScene(levels[_levelArrayIdx]);
    }
}

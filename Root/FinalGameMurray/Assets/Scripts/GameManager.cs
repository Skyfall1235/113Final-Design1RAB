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
        CheckLevelWin();
        PotionManagement();
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
    public void CheckLevelWin()
    {
        //if (coins == 10)
        //{
        //    youWinPanel.SetActive(true);
        //    allowInput = false;
        //}
    }

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
    public void UpdateData(int hp)
    {
        coinText.text = ($"Player HP: {hp}\n Coins Collected:{coins}");
    }
    #endregion
    void ChangeColorOfText()
    {
        if (coins >= 10)
        {
            timeText.color = Color.red;
            timerAllowed = false;
        }
        
    }
    void PotionManagement()
    {
        if (allowInput)
        {
            if (Input.GetKeyDown(KeyCode.R) && potions[0] > 0)
            {
                //give player health back
                if (health >= 100) { return; }
                Player.GetComponent<BallPlayerController>().HealSelf();
                Debug.Log("gave 10 health");
                potions[0]--;
                UpdateData(health);
            }
            if (Input.GetKeyDown(KeyCode.G) && potions[1] > 0)
            {
                //if player is already invincible, dont do it
                if (Player.GetComponent<BallPlayerController>().isInvincible == true) { return; }
                //short invincibilty
                Player.GetComponent<BallPlayerController>().InvicibilityTime(5);
                potions[1]--;
                UpdateData(health);
            }
            if (Input.GetKeyDown(KeyCode.B) && potions[2] > 0)
            {
                //if player is already invincible, dont do it
                Debug.Log("is invincible");
                if (Player.GetComponent<BallPlayerController>().isInvincible == true) { return; }
                //longer invincibility
                Player.GetComponent<BallPlayerController>().InvicibilityTime(10);
                potions[2]--;
                UpdateData(health);
            }
        }
    }
    public void ShiftScene(int _levelArrayIdx)
    {
        
        string[] levels = new string[] { "DesignLevelOne", "DesignLevelTwo", "WinScene" };

        SceneManager.LoadScene(levels[_levelArrayIdx]);
    }
}

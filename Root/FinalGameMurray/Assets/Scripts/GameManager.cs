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

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Player;


    public int[] potions = new int[3] { 0, 0, 0 };
    [SerializeField] private int health = 100;
    public int coins = 0;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject youWinPanel;
    [SerializeField] TextMeshProUGUI UIText;
    

    [SerializeField] private bool allowInput;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = Player.GetComponent<BallPlayerController>().health;
        CheckLevelWin();
        PotionManagement();
    }
    public void HandleGameOver()
    {
        gameOverPanel.SetActive(true);
        allowInput = false;
    }
    public void CheckLevelWin()
    {
        if (coins == 10)
        {
            youWinPanel.SetActive(true);
            allowInput = false;
        }
    }
    public void Restart()
    {
        //set potions counts to 0
        //reload level
    }
    public void GotoNextLevel()
    {
        Debug.Log("Next Level");
    }
    public void UpdateData(int hp)
    {
        UIText.text = ($"Player HP: {hp}\n Health Potions:{potions[0]}\n Invincibility Potions:{potions[1]}\n longer Invincibility Potions:{potions[2]}\n Coins Collected:{coins}");
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
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject[] canvas = new GameObject[2];
    //0 is start, 1 is help
    public void StartButton()
    {
        SceneManager.LoadScene("DesignLevelOne");
    }
    public void HelpButton()
    {
        //turn off start screen and turn on help screen
        canvas[0].SetActive(false);
        canvas[1].SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ReturnButton()
    {
        //turn off help screen and turn on start screen
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
    }
}

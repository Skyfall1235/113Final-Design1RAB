using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private ScriptableObjectCreation SO_Creation;
    [SerializeField] private TextMeshProUGUI winText;
    // Start is called before the first frame update
    void Start()
    {
        winText.text = $"You Completed the game in {TicksToTimeConversion((int)SO_Creation.totalTime)}";
    }
    string TicksToTimeConversion(int Ticks)
    {
        //if thers s60 seconds passed, increment the minute and restart
        int Minutes = Ticks / 60;
        int seconds = Ticks % 60;
        return $"{Minutes} minutes, {seconds} seconds";
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}

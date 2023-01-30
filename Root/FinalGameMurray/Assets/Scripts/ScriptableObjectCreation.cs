using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tools", menuName = "ScriptableObjects/Tools/PlayerInfo")]
public class ScriptableObjectCreation : ScriptableObject
{
    public float levelOneTime;
    public float levelTwoTime;
    public float levelThreeTime;
    public float totalTime;

    public int deaths;

    public int currentLevel;
}

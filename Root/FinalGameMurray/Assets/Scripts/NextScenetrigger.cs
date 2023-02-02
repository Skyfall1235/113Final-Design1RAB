using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenetrigger : MonoBehaviour
{
    
    [SerializeField] private int levelToGoTo;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private ScriptableObjectCreation playerData;
    // Start is called before the first frame update
    void Start()
    {
        levelToGoTo = playerData.currentLevel + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameManager.GetComponent<GameManager>().coins == 10)
        {
            //save the data first
            gameManager.GetComponent<GameManager>().SaveData(playerData.currentLevel);
            //send us over to thew next scene
            gameManager.GetComponent<GameManager>().ShiftScene(levelToGoTo);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenetrigger : MonoBehaviour
{
    
    [SerializeField] private int levelToGoTo;
    [SerializeField] private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShiftScene(levelToGoTo);
        }
    }
}

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
using UnityEngine.EventSystems;

public class BallPlayerController : MonoBehaviour
{
    [Header("States and references")]
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;
    private Rigidbody playerRB;
    [SerializeField] private Transform camTransform;
    Vector3 moveDirection;
    //[SerializeField] private GameObject GameManager;
    public bool isInvincible = false;

    [Header("lives")]
    public int health = 100;
    [SerializeField] private int healValue = 10;
    
    #region Start, Update, and FixedUpdate
    void Start()
    {
        //i needed the rigidbody to make it move, gotta put it somewhere
        playerRB = GetComponent<Rigidbody>();
        //GameManager.GetComponent<GameManager>().UpdateData(health);

    }
    private void Update()
    {
        //basic camera controls, which help out the camera controller
        Quaternion cameraRot = camTransform.transform.rotation;
        transform.rotation = cameraRot;
        //GameManager.GetComponent<GameManager>().UpdateData(health);
    }
    void FixedUpdate()
    {
        //gets the axis values, then multiplies them by the speed all at once
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveDirection = camTransform.forward * moveVertical + camTransform.right * moveHorizontal;

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRB.AddForce(moveDirection.normalized * sprintSpeed, ForceMode.Force);
        }
        else
        {
            playerRB.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }
    }
    #endregion
    #region Trigger Conditions
    void OnTriggerEnter(Collider other)
    {
        //if the object is a pickup, turn it off and add 1 to the counter
        if (other.gameObject.tag == ("Health Potion"))
        {
            other.gameObject.SetActive(false);
            //play a pickup sound effect
            //GameManager.GetComponent<SoundManager>().PlayAudioClip(1);
            //GameManager.GetComponent<GameManager>().potions[0]++;

        }
        if (other.gameObject.tag == ("Invincible Potion"))
        {
            other.gameObject.SetActive(false);
            //play a pickup sound effect
            //GameManager.GetComponent<SoundManager>().PlayAudioClip(1);
            //GameManager.GetComponent<GameManager>().potions[1]++;

        }
        if (other.gameObject.tag == ("Invincible x2 Potion"))
        {
            other.gameObject.SetActive(false);
            //play a pickup sound effect
            //GameManager.GetComponent<SoundManager>().PlayAudioClip(1);
            //GameManager.GetComponent<GameManager>().potions[2]++;

        }
        if (other.gameObject.tag == ("Coin"))
        {
            other.gameObject.SetActive(false);
            //play a pickup sound effect
            //GameManager.GetComponent<SoundManager>().PlayAudioClip(2);
            //GameManager.GetComponent<GameManager>().coins++;

        }
        if (other.gameObject.tag == ("Bomb") && !isInvincible)
        {
            other.gameObject.SetActive(false);
            TakeDamage(10);    
            //play a pickup sound effect
            //GameManager.GetComponent<SoundManager>().PlayAudioClip(3);
            if (health <= 0)
            {
                //GameManager.GetComponent<GameManager>().HandleGameOver();
            }
        }
    }
    //funky n fun takedamage method with is very reusable (its in like 4 projects of mine)
    public void TakeDamage(int damageValue)
    {
        Debug.Log($"taken {damageValue} damage");
        health -= damageValue;
        //GameManager.GetComponent<GameManager>().UpdateData(health);
    }

    #endregion
    #region player on world interaction
    //croutine
    public IEnumerator InvicibilityTime(float time)
    {
        StartInvincible();
        Debug.Log("is invincible");
        yield return new WaitForSeconds(time);
        endInvincibility();
        Debug.Log("is not invincible");
    }
    public void StartInvincible()
    {
        isInvincible = true;
    }
    public void endInvincibility()
    {
        isInvincible = false;
    }
    public void HealSelf()
    {
        health += healValue;
    }
    #endregion
}


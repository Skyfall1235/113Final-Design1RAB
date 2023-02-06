using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPads : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] private float launchSpeed = 2;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
    private void OnTriggerStay(Collider other)
    {
        gameManager.GetComponent<SoundManager>().PlayAudioClip(1);
        Rigidbody playerRB = other.gameObject.GetComponent<Rigidbody>();
        playerRB.AddForce(Vector3.up * launchSpeed, ForceMode.Impulse);
    }
}

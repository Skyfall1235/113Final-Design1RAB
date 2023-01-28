using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPads : MonoBehaviour
{
    [SerializeField] private float launchSpeed = 2;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        Rigidbody playerRB = other.gameObject.GetComponent<Rigidbody>();
        playerRB.AddForce(Vector3.up * launchSpeed, ForceMode.Impulse);
    }
}

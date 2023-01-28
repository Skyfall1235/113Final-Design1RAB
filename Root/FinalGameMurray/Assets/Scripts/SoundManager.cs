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

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    //get a source, and get audio clips
    [SerializeField] private AudioSource audioSource;
    //the audio and volume stored in lists
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] List<float> audioVolume = new List<float>();
    public void PlayAudioClip(int clipNumber)
    {
        //make sure the audiosource exists first
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioClips[clipNumber], audioVolume[clipNumber]);
        }
    }
}

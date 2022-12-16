using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripwireCollider : MonoBehaviour
{
    private Boolean triggered = false;
    public GameObject[] activateList;
    public GameObject[] deactivateList;
    public AudioSource source;
    public AudioSource ambienceSource;
    //public AudioSource ambienceSource;
    public AudioClip oneShotClip;
    public AudioClip ambienceClip;
    
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Player" && triggered == false)
        {
            triggered = true;
            foreach (GameObject obj in activateList)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in deactivateList)
            {
                obj.SetActive(false);
            }

            if (source != null && oneShotClip != null)
            {
                source.PlayOneShot(oneShotClip, 1f);
            }

            if (ambienceSource != null && ambienceClip != null) {
                ambienceSource.clip= ambienceClip;
                ambienceSource.Play();
            }
            Debug.Log("You have successfully walked through a wall. Good job. ");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ItemInteractable : MonoBehaviour
{   

    public TextMeshProUGUI uiText;
    public string message;
    public AudioSource source;
    public AudioClip clip;
    public FirstPersonController playerController;
    public void Interact() {
        playerController.enabled= false;    
        uiText.SetText(message);
        source.PlayOneShot(clip, 1f);
        Time.timeScale = 0;
    }
}

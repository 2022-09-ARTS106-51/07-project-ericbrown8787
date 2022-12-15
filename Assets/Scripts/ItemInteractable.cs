using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteractable : MonoBehaviour
{   

    public TextMeshProUGUI uiText;
    public string message;
    public AudioSource source;
    public AudioClip clip;
    public void Interact() {
        uiText.SetText(message);
        source.PlayOneShot(clip, 1f);
    }
}

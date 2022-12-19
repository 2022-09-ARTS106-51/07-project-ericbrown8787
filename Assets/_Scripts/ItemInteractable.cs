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
    public FirstPersonController playerController;
    public GameObject panel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            uiText.SetText(message);
            panel.SetActive(true);
            uiText.ForceMeshUpdate();   
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            uiText.SetText("");
            panel.SetActive(false);
            uiText.ForceMeshUpdate(); 
        }
    }

}
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerInteract : MonoBehaviour
{

    public GameObject panel;
    public TextMeshProUGUI uiText;
    public FirstPersonController playerController;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {


            { 

            float interactRange = 1f;
                
                Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out ItemInteractable interactable))
                {
                        if (panel.activeSelf == true)
                        {
                            playerController.enabled = true;
                            uiText.SetText("");
                            Time.timeScale = 1;
                            panel.SetActive(false);
                        } 
                        else
                        {
                            panel.SetActive(true);
                            interactable.Interact();
                        }

                    }
            }
                
            }
            uiText.ForceMeshUpdate();
        }
    }
}




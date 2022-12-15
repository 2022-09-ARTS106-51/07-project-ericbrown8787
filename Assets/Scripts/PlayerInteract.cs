using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteract : MonoBehaviour
{


    public TextMeshProUGUI uiText;
    public FirstPersonController playerController;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            if (Time.timeScale == 0) {
                playerController.enabled = true;
                uiText.SetText("");
                Time.timeScale = 1;
            }
            else { 

            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out ItemInteractable interactable))
                {
             
                        interactable.Interact();
                        
                }
            }
            }
            uiText.ForceMeshUpdate();
        }
    }
}




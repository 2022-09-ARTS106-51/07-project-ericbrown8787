using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{


    public TextMeshProUGUI uiText;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (uiText.text.Length > 0) { 
            uiText.SetText("");
            }
            else { 

            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out ItemInteractable npcInteractable))
                {
             
                        npcInteractable.Interact();
                        
                    }
            }
            }
            uiText.ForceMeshUpdate();
        }
    }
}




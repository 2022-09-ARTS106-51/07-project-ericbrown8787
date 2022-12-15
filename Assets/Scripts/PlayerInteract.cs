using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{


    public TextMeshProUGUI uiText;
    public void ClearText()
    {
        uiText.SetText("");
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
               ClearText();
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out ItemInteractable npcInteractable))
                {
                    npcInteractable.Interact();
                }
            }
        }
    }
}




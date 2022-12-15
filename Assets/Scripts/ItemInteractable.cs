using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInteractable : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public string message;
    public void Interact() {
        uiText.SetText(message);
    }
}

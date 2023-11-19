using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact_UI_Script : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Interaction_Controller playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteraction interactable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}

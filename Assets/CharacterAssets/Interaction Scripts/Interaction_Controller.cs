using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float interactRange ;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteraction interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    public IInteraction GetInteractableObject()
    {
        List<IInteraction> interactableList = new();

        
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange, 8);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteraction interactable))
            {
                interactableList.Add(interactable);
            }
        }
        Debug.Log(interactableList);


        IInteraction closestInteractable = null;
        foreach (IInteraction interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    // Closer
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}

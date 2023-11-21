using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class Interaction_Controller : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float interactRange;



    // Update is called once per frame
    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteraction interactable = GetInteractableObject();

            if (interactable != null)
            {
                GameObject interactObject = interactable.GetAttachment();
                string objectName = interactObject.name;
                RequestInteractServerRpc(objectName);
                Interact(objectName);
            }

        }
    }

    [ServerRpc]
    private void RequestInteractServerRpc(string interactable)
    {
        InteractClientRpc(interactable);
    }

    [ClientRpc]
    private void InteractClientRpc(string interactable)
    {
        if (!IsOwner) Interact(interactable);
    }


    private void Interact(string name)
    {
        if (name != null)
        {


            GameObject targetObject = GameObject.Find(name);



            if (targetObject.TryGetComponent(out IInteraction interactable))
            {
                Debug.Log(interactable);
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

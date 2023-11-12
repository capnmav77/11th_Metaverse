using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{

    [SerializeField]
    private Transform interactorSource;
    [SerializeField]
    private float interactorRange;
    [SerializeField]
    private CrossHair crossHair;

 
    void Update()
    {
        Ray r = new Ray(interactorSource.position,interactorSource.forward);
        if(Physics.Raycast(r,out RaycastHit hitInfo, interactorRange))
        {
            
          
            if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                
                if (crossHair)
                {
                    crossHair.InteractionCorsshair(true);
                }
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact();
                }
            }
            else
            {
                if(crossHair)
                crossHair.InteractionCorsshair(false);
            }
        }

    }
}

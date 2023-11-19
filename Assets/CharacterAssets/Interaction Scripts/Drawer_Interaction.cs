using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer_Interaction : MonoBehaviour, IInteraction
{
    // Start is called before the first frame update

    [SerializeField] private string interactText;

    


    public void Interact()
    {
        Debug.Log(interactText);
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }



}

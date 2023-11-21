using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer_Interaction : MonoBehaviour, IInteraction
{
    // Start is called before the first frame update

    [SerializeField] private string interactText;

    private bool isOpened = false;


    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }



    public void Interact()
    {
        isOpened = !isOpened;

        animator.SetTrigger("openTrigger");
    }

    public string GetInteractText()
    {
        if (isOpened)
        {
            return "Close " + interactText + " Drawer";
        }
        return "Open " + interactText + " Drawer";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public GameObject GetAttachment()
    {
        return gameObject;
    }



}

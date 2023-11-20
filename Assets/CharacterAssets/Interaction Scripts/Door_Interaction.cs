using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour, IInteraction
{
    // Start is called before the first frame update


    private bool isOpened = false;
    [SerializeField] GameObject door;

    Animator animator;

    void Start()
    {
        animator = door.GetComponent<Animator>();

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
            return "Close Door";
        }
        return "Open Door";
    }

    public Transform GetTransform()
    {
        return transform;
    }



}
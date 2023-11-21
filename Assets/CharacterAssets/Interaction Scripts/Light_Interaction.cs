using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Interaction : MonoBehaviour, IInteraction
{

    private bool isTurnedOn = false;
    
    public string GetInteractText()
    {
        if (isTurnedOn){
            return "Turn Off Light";
        }
        return "Turn On Light";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        isTurnedOn = !isTurnedOn;
        GameObject[] lights = GameObject.FindGameObjectsWithTag("room_lights");
        
        if (isTurnedOn){
                foreach (GameObject light in lights){
                    light.GetComponent<Light>().enabled = true;
                }
        }
        else {
            foreach (GameObject light in lights)
            {
                light.GetComponent<Light>().enabled = false;
            }
        }


    }

    public GameObject GetAttachment()
    {
        return gameObject;
    }
}

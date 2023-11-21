using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction {

    void Interact();
    string GetInteractText();
    Transform GetTransform();

    GameObject GetAttachment();

}
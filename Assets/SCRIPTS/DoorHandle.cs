using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Transform handler;
    public GameObject grabbablehandler;
    public void ResetPos()
    {
        grabbablehandler.transform.position = handler.transform.position;
        grabbablehandler.transform.rotation = handler.transform.rotation;
    }
}

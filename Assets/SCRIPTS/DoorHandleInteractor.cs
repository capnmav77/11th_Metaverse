using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleInteractor : MonoBehaviour,IInteractable
{

    [SerializeField]
    private Transform handle;

    private HingeJoint doorHinge;
    [SerializeField]
    private GameObject door;

    public float upperBound;
    public float lowerBound;

    public float doorSpeed;


    public float speed;

    public bool activated = false;
    private bool doorState = false;
    private bool doorSwingState = false;
    private bool doorOpen = false;

    void Start()
    {
        doorHinge = door.GetComponent<HingeJoint>();
     
    }
    public void Interact()
    {
        if (!activated)
            activated = true;
        doorState = !doorState;
        
    }
   

    void OpenHandle()
    {
        handle.Rotate(new Vector3(0, 0, -speed * Time.deltaTime), Space.Self);
    }

    void CloseHandle()
    {
        
        handle.Rotate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
        if (handle.localEulerAngles.z >= lowerBound)
            activated = false;
        
    }

    void OpenDoor()
    {
        
        if (doorSwingState!=doorState)
        {
            JointMotor motor = doorHinge.motor;
            motor.targetVelocity = doorSpeed;
            doorHinge.motor = motor;
            doorSwingState = doorState;
        }

       
        if (door.transform.rotation.z >= 0.56 )
        {
            doorOpen = true;
        }
    }

    void CloseDoor()
    {
        
        if (doorSwingState != doorState)
        {
            JointMotor motor = doorHinge.motor;
            motor.targetVelocity = -doorSpeed;
            doorHinge.motor = motor;
            doorSwingState = doorState;
        }
        if (door.transform.rotation.z <= 0.01 )
        {
            doorOpen = false;
        }
    }

    

    void Update()
    {
        if (activated && doorState)
        {
            if (handle.localRotation.eulerAngles.z > upperBound && doorState != doorOpen)
                OpenHandle();
            else if (doorOpen != doorState)
                OpenDoor();
            else
                CloseHandle();
        }
       else if(activated && !doorState)
        {

            if (handle.localRotation.eulerAngles.z > upperBound && doorState!=doorOpen)
                OpenHandle();
            else if (doorOpen != doorState)
                CloseDoor();
            else
                CloseHandle();
        }
       
    }
}

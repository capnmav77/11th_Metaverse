using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class TPS_Controller : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update

    public float turnSmoothTime = 0.1f;

    public float runMultiplier = 2f;

    public float runAcceleration = 5.0f;

    private float runningBoost = 1.0f;

    PhotonView PV;

    float turnSmoothVelocity;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        // if (PV!=null && !PV.IsMine)
        // {
        //     Debug.Log("PV is not mine");
        //     Destroy(GetComponentInChildren<Camera>().gameObject);
        //     Destroy(GetComponentInChildren<Camera>().gameObject);
        //     Destroy(GetComponentInChildren<AudioListener>().gameObject);
        // }
    }

    void HandleRunningBoostTransition(bool condition)
    {
        // Adjust the runningBoost based on the condition
        if (condition)
        {
            // Increase runningBoost towards runMultiplier
            runningBoost = Mathf.Lerp(runningBoost, runMultiplier, Time.deltaTime * runAcceleration);
        }
        else
        {
            // Decrease runningBoost back to 1.0
            runningBoost = Mathf.Lerp(runningBoost, 1.0f, Time.deltaTime * runAcceleration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine){
           HandleMovement();
        }
        
    }

    void HandleMovement(){
        float playerVerticalInput = Input.GetAxisRaw("Vertical");
        float playerHorizontalInput = Input.GetAxisRaw("Horizontal");
        bool condition = Input.GetKey(KeyCode.LeftShift);

        HandleRunningBoostTransition(condition);

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        Vector3 relativeForwardMovement = playerVerticalInput * forward;
        Vector3 relativeHorizontalMovement = playerHorizontalInput * right;


        Vector3 relativeMovement = runningBoost * speed * Time.deltaTime * (relativeForwardMovement + relativeHorizontalMovement);
        relativeMovement.y = 0;

        if (relativeMovement.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(relativeMovement.x, relativeMovement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

    }
}

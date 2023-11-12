using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS_Controller : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update

    public float turnSmoothTime = 0.1f;

    public float runMultiplier = 1.5f;
    float turnSmoothVelocity;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float playerVerticalInput = Input.GetAxisRaw("Vertical");
        float playerHorizontalInput = Input.GetAxisRaw("Horizontal");
        float runningBoost = Input.GetKey(KeyCode.LeftShift) ? runMultiplier : 1.0f;




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

        transform.Translate(relativeMovement, Space.World);

    }
}

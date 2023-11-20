using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float mouseSensitivity = 100f;

    [SerializeField]  Transform targetBody;
    [SerializeField] Transform player;



    float xRotation = 0f;
    float yRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;



        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        transform.position = targetBody.position;

        
    }
}

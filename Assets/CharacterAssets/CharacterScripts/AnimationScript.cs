using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    Animator animator;
    public float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    public float runMultiplier = 2.0f;

    int VelocityHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        VelocityHash = Animator.StringToHash("velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D));
        bool runPressed = Input.GetKey(KeyCode.LeftShift) && forwardPressed;

        if (runPressed)
        {
            velocity += Time.deltaTime * acceleration * runMultiplier;
        }
        if (forwardPressed && !runPressed && velocity < 0.5f)
        {
            velocity += Time.deltaTime * deceleration;
            velocity = Mathf.Clamp(velocity, 0, 0.5f);
        }
        if (forwardPressed && !runPressed && velocity > 0.5f)
        {
            velocity -= Time.deltaTime * 0.5f;
        }

        if (!forwardPressed && velocity > 0)
        {
            velocity -= Time.deltaTime * deceleration;
        }


        velocity = Mathf.Clamp(velocity, 0, 1);


        animator.SetFloat(VelocityHash, velocity);
    }


}

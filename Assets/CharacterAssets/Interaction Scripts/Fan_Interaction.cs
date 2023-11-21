using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_Interaction : MonoBehaviour, IInteraction
{

    private bool isTurnedOn = true;

    private Animator anim;

    float speed = 2;

    [SerializeField] float acceleration = 1;

    void Awake()
    {
        GameObject fan = GameObject.FindGameObjectWithTag("room_fan");
        anim = fan.GetComponent<Animator>();

    }

    void Update()
    {
        if (isTurnedOn)
        {
            speed += Time.deltaTime * acceleration;
        }
        else
        {
            speed -= Time.deltaTime * acceleration;
        }

        speed = Mathf.Clamp(speed, 0, 2);

        anim.speed = speed;

    }

    public string GetInteractText()
    {
        if (isTurnedOn)
        {
            return "Turn Off Fan";
        }
        return "Turn On Fan";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact()
    {
        isTurnedOn = !isTurnedOn;

    }

    public GameObject GetAttachment()
    {
        return gameObject;
    }

    // Start is called before the first frame update

}

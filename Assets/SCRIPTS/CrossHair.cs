using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{

    private RectTransform reticle;
    private float currentSize;

    public float restingSize;
    public float activatedSize;
    public float speed;

    
   
    void Start()
    {
        reticle = GetComponent<RectTransform>();
        reticle.sizeDelta = new Vector2(restingSize, restingSize);
    }

    public void InteractionCorsshair(bool isActivated)
    {

        if (isActivated)
        {
            currentSize = Mathf.Lerp(currentSize, activatedSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

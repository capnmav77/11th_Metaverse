using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoider : MonoBehaviour
{
    public BoxCollider b1;
    public BoxCollider b2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "controller")
        {
            //Physics2D.IgnoreCollision(collision.collider, transform.GetComponent<BoxCollider>());
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        Debug.Log(collision.collider.tag);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnforcer : MonoBehaviour
{
    new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Ball")) return;
        //ContactPoint2D[] contacts = collision.collider.GetContacts();
    }
}

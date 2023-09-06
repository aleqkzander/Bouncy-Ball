using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 100.0f;
    new private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody.velocity = Vector2.up * ballSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Return when not ball
        if (!collision.gameObject.CompareTag("Player")) return;

        // Calculate hit Factor
        float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

        // Calculate direction, set length to 1
        Vector2 direction = new Vector2(x, 1).normalized;

        // Set velocity with direction * speed
        rigidbody.velocity = direction * ballSpeed;

        transform.localScale = new(direction.x, direction.y);
    }

    private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}

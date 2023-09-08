using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 15.0f;
    new Rigidbody2D rigidbody;

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
        if (!collision.gameObject.CompareTag("Player")) return;

        // Shoot the ball acording to his impactpoint on the player
        float x = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
        Vector2 dir = new Vector2(x, 1).normalized;
        rigidbody.velocity = dir * ballSpeed;
    }
}

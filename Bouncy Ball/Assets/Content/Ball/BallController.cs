using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject playerSprite;
    public GameObject collisionObject;
    public float ballSpeed = 15.0f;
    new Rigidbody2D rigidbody;
    private Vector2 squashScale = new(0.4f, 0.6f);
    private Vector2 velSquash;

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
        ContactPoint2D collisionPoint = collision.contacts[0];
        Instantiate(collisionObject, collisionPoint.point, Quaternion.identity);

        if (!collision.gameObject.CompareTag("Player")) return;

        // Shoot the ball acording to his impactpoint on the player
        float x = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
        Vector2 direction = new Vector2(x, 1).normalized;
        rigidbody.velocity = direction * ballSpeed;
    }

    private void SquashAndStretch()
    {
        playerSprite.transform.localScale = Vector2.SmoothDamp(playerSprite.transform.localScale, squashScale, ref velSquash, 0.1f);
        Vector2 direction = rigidbody.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        playerSprite.transform.rotation = Quaternion.Slerp(playerSprite.transform.rotation, targetRotation, Time.deltaTime * 50f);
    }

    private void Update()
    {
        SquashAndStretch();
    }
}

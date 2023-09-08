using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject PauseUI;
    new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1.0f;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rigidbody.transform.position = new(mousePosition.x, transform.position.y);
        }
        else
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }
}

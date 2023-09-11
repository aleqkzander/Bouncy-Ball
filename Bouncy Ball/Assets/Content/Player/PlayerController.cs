using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    private bool drag = false;
    public GameObject PauseUI;
    new private Rigidbody2D rigidbody;
    public PostProcessVolume postProcessing;
    private ChromaticAberration aberration;
    private AudioController audioController;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        postProcessing.profile.TryGetSettings(out aberration);
        audioController = FindObjectOfType<AudioController>();
    }

    private void OnMouseDown()
    {
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!drag) return;
            aberration.active = false;
            PauseUI.SetActive(false);
            Time.timeScale = 1.0f;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rigidbody.transform.position = new(mousePosition.x, transform.position.y);
            audioController.DisableFilter();
        }
        else
        {
            aberration.active = true;
            PauseUI.SetActive(true);
            Time.timeScale = 0.1f;
            audioController.EnableFilter();
        }
    }
}

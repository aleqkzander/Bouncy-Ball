using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioLowPassFilter filter;
    public static AudioController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableFilter()
    {
        filter.enabled = true;
    }

    public void DisableFilter()
    {
        filter.enabled = false;
    }
}

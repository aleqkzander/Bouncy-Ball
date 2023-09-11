using UnityEngine;

public class ArenaScaler : MonoBehaviour
{
    private readonly float aspectRate = 1.77f;

    private void Update()
    {
        float aspect = Camera.main.aspect;
        transform.localScale = new(aspect / aspectRate, 1, 1);
    }
}

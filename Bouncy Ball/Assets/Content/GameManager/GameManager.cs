using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadMainScene() { Time.timeScale = 1f; SceneManager.LoadScene(0); }
}

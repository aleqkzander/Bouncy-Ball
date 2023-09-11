using System.Collections;
using UnityEngine;

public class BombCollision : MonoBehaviour
{
    private GameManager gameManager;
    private void Awake() => gameManager = FindObjectOfType<GameManager>();
    private void Start() => StartCoroutine(EndGameScene());

    private IEnumerator EndGameScene()
    {
        yield return new WaitForSeconds(1);
        gameManager.GetComponent<PlayerStatistic>().SetScore();
        gameManager.LoadMainScene();
    }
}

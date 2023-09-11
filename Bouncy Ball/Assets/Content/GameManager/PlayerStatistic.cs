using TMPro;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    public string playerName = "";
    public int playerScore;
    public int gameInstanceScore;
    public TMP_Text playerScoreText;

    private void Awake()
    {
        playerName = PlayerPrefs.GetString("name");
        playerScore = PlayerPrefs.GetInt("score");
    }

    public void SetScore()
    {
        // Only update the highscore
        if (gameInstanceScore > playerScore)
            playerScore = gameInstanceScore;

        PlayerPrefs.SetInt("score", playerScore);
    }

    private void Update()
    {
        playerScoreText.text = $"Highscore - {playerScore:0000000000}\nCurrentscore - {gameInstanceScore:0000000000}";
    }
}

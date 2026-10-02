using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("UI Text References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI pelletsText;

    // Оновлення тексту очок
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Оновлення тексту життів
    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    // Оновлення тексту пелетів
    public void UpdatePellets(int collected, int target)
    {
        if (pelletsText != null)
        {
            pelletsText.text = "Pellets: " + collected + "/" + target;
        }
    }
}
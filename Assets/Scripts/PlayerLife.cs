using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int lives = 3;
    private Vector2 startPosition;

    [Header("References")]
    public GameUI gameUI; // Посилання на UI для оновлення життів

    void Start()
    {
        startPosition = transform.position;

        // Встановлюємо початкову кількість життів на екрані
        if (gameUI != null)
        {
            gameUI.UpdateLives(lives);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        lives--;
        Debug.Log("Життя втрачено! Залишилось: " + lives);

        // Оновлюємо UI життів
        if (gameUI != null)
        {
            gameUI.UpdateLives(lives);
        }

        if (lives > 0)
        {
            transform.position = startPosition;
        }
        else
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
            // Тут у майбутньому можна показати панель Game Over
        }
    }
}
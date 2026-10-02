using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public int lives = 3;
    private Vector2 startPosition;

    [Header("References")]
    public GameUI gameUI; 
    public MonoBehaviour playerMovementScript;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (gameUI != null)
        {
            gameUI.UpdateLives(lives);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            // Запускаємо процес зіткнення замість миттєвої смерті
            StartCoroutine(HandleHitRoutine());
        }
    }

    IEnumerator HandleHitRoutine()
    {
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (spriteRenderer != null) spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.15f); // Час зникнення

            if (spriteRenderer != null) spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.15f); // Час появи
        }

        lives--;
        Debug.Log("Життя втрачено! Залишилось: " + lives);

        if (gameUI != null)
        {
            gameUI.UpdateLives(lives);
        }

        if (lives > 0)
        {
            transform.position = startPosition;

            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
            }
        }
        else
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.TriggerGameOver();
            }
        }
    }
}
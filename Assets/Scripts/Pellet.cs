using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Повідомляємо GameManager, що пелет зібрано
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CollectPellet();
            }

            // Знищуємо пелет
            Destroy(gameObject);
        }
    }
}
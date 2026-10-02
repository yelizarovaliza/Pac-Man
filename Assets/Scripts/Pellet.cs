using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 10;
    public AudioClip collectSound; // Перетягни сюди свій аудіофайл у префабі

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Повідомляємо GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CollectPellet();
            }

            // Програємо звук на місці пелета, навіть якщо об'єкт знищиться
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Знищуємо пелет
            Destroy(gameObject);
        }
    }
}
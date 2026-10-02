using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Settings")]
    public int targetPellets = 50;
    private int collectedPellets = 0;
    private int score = 0;

    [Header("References")]
    public GameUI gameUI;
    public GameObject winPanel;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Ініціалізуємо початковий стан UI на старті гри
        if (gameUI != null)
        {
            gameUI.UpdateScore(score);
            gameUI.UpdatePellets(collectedPellets, targetPellets);
        }
    }

    // Метод, який викликається, коли Пакман з'їв пелет
    public void CollectPellet()
    {
        collectedPellets++;
        score += 10; // Кожен пелет дає 10 очок

        // Передаємо нові дані в UI
        if (gameUI != null)
        {
            gameUI.UpdateScore(score);
            gameUI.UpdatePellets(collectedPellets, targetPellets);
        }

        Debug.Log("Зібрано пелетів: " + collectedPellets + "/" + targetPellets);

        if (collectedPellets >= targetPellets)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("ПЕРЕМОГА!");
        Time.timeScale = 0f;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
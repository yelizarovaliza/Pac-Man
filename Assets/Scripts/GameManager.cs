using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuration")]
    public GameConfig config; // Перетягни сюди наш ScriptableObject файл

    private int collectedPellets = 0;  
    private int score = 0;             

    [Header("UI References")]
    public GameUI gameUI;              
    public GameObject resultPanel;     
    public TextMeshProUGUI resultText; 

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
        }

        if (gameUI != null && config != null)
        {
            gameUI.UpdateScore(score);
            gameUI.UpdatePellets(collectedPellets, config.targetPellets);
        }
    }

    public void CollectPellet()
    {
        collectedPellets++;
        score += (config != null ? config.pelletScoreValue : 10); 

        if (gameUI != null && config != null)
        {
            gameUI.UpdateScore(score);
            gameUI.UpdatePellets(collectedPellets, config.targetPellets);
        }

        int target = config != null ? config.targetPellets : 50;
        if (collectedPellets >= target)
        {
            TriggerWin();
        }
    }

    public void TriggerWin()
    {
        ShowResultScreen("ПЕРЕМОГА!");
    }

    public void TriggerGameOver()
    {
        ShowResultScreen("ГРУ ЗАВЕРШЕНО");
    }

    void ShowResultScreen(string message)
    {
        Time.timeScale = 0f; 

        if (resultText != null)
        {
            resultText.text = message;
        }

        if (resultPanel != null)
        {
            resultPanel.SetActive(true); 
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
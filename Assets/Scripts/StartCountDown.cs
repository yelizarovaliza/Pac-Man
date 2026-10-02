using UnityEngine;
using TMPro;
using System.Collections;

public class StartCountdown : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI countdownText; // Посилання на наш текст на екрані
    public MonoBehaviour[] scriptsToDisable; // Сюди додамо скрипти руху Пакмана та привидів

    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        // 1. Вимикаємо рух  на початку відліку
        foreach (var script in scriptsToDisable)
        {
            if (script != null) script.enabled = false;
        }

        // 2. Цикл відліку: 3 -> 2 -> 1
        for (int i = 3; i > 0; i--)
        {
            if (countdownText != null)
            {
                countdownText.text = i.ToString();
            }
            yield return new WaitForSeconds(1f); // Чекаємо 1 секунду
        }

        if (countdownText != null)
        {
            countdownText.text = "GO!";
        }
        yield return new WaitForSeconds(0.5f);

        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
        }

        foreach (var script in scriptsToDisable)
        {
            if (script != null) script.enabled = true;
        }
    }
}
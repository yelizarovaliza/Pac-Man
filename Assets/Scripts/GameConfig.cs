using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    [Header("Player Settings")]
    public int maxLives = 3;

    [Header("Game Rules")]
    public int targetPellets = 50;
    public int pelletScoreValue = 10;

    [Header("Ghost & Enemy Settings")]
    public float ghostSpeed = 3f;
}
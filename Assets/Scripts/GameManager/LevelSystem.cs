
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int currentLevel = 1;

    [Header("Chest Conditions")]
    [SerializeField] private int killsPerLevel = 5;
    [SerializeField] private float timeWindow = 10f;

    [Header("Chest")]
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance = 1.5f;

    private int kills;
    private float timer;
    private bool chestSpawned;

    private void Update()
    {
        if (chestSpawned)
            return;

        timer += Time.deltaTime;

        if (timer >= timeWindow)
        {
            kills = 0;
            timer = 0f;
        }
    }

    public void RegisterKill()
    {
        if (chestSpawned)
            return;

        kills++;

        int killGoal = currentLevel * killsPerLevel;

        Debug.Log($"Abates: {kills}/{killGoal}");

        if (kills >= killGoal)
        {
            SpawnChest();
        }
    }

    private void SpawnChest()
    {
        if (chestPrefab == null || player == null)
        {
            Debug.LogWarning(
                "Configure o prefab do baú e o Player no Inspector!"
            );
            return;
        }

        Vector2 spawnPosition =
            (Vector2)player.position + Random.insideUnitCircle.normalized
            * spawnDistance;

        Instantiate(chestPrefab, spawnPosition, Quaternion.identity);

        chestSpawned = true;

        Debug.Log("Baú criado!");
    }

    public void LevelUp()
    {
        currentLevel++;

        Debug.Log($"Subiu para o nível {currentLevel}!");
    }
}

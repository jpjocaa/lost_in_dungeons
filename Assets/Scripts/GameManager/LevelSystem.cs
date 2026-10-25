using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int currentLevel = 1;

    [Header("Level up conditions")]
    [SerializeField] private int killsPerLevel = 5;
    [SerializeField] private float timeWindow = 10f;

    private int kills;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeWindow) //Se n consegui subir de nivel zera.
        {
            kills = 0;
            timer = 0f;
        }
    }

    public void RegisterKill()
    {
        kills++;

        int killGoal = currentLevel * killsPerLevel;

        Debug.Log($"Kills totais: {kills}/{killGoal}");

        if (kills >= killGoal)
        {
            SpawnChest();

            
            LevelUp();
        }
    }

    private void SpawnChest()
    {
        Debug.Log($"Subiu de Nivel! no futuro deve fazer um báu surgir. Nivel atual = {currentLevel}");

        kills = 0;
        timer = 0f;
        
    }

    public void LevelUp()
    {
        currentLevel += 1;

        Debug.Log($"Subiu para o nível {currentLevel}!");
    }
}

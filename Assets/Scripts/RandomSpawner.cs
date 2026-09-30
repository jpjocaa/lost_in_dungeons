using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.AI;
using System.Numerics;
public class RandomSpawner : MonoBehaviour
{
    [Header("Spawner settings")]
    [SerializeField] private GameObject[] enemyprefarbs;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float spawnRadius = 12f;

    private float timer = 0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(player == null ) return;
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = enemyprefarbs[Random.Range(0, enemyprefarbs.Length)]; //pega um inimigo aleatorio. Por enquanto só tem 1 ent n muda nada
        UnityEngine.Vector2 spawnPosition = (UnityEngine.Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemy,spawnPosition, UnityEngine.Quaternion.identity);
    }
}

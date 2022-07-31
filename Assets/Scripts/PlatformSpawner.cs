using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float minSpawnHeight = 1f;
    [SerializeField] private float maxSpawnHeight = 4f;
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float maxSpawnInterval = 4f;
    [SerializeField] private float spawnOffsetX = 10f;
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private float powerupChance = 0.1f;

    private float spawnThreshold = 0f;

    private void Update()
    {
        if (GameManager.Player.transform.position.x > spawnThreshold)
        {
            spawnThreshold += Random.Range(minSpawnInterval, maxSpawnInterval);
            float spawnX = GameManager.Player.transform.position.x + spawnOffsetX;
            float spawnY = Random.Range(minSpawnHeight, maxSpawnHeight);

            Instantiate(platformPrefab, new Vector2(spawnX, spawnY), Quaternion.identity);

            if (Random.value < powerupChance)
            {
                Instantiate(powerupPrefab, new Vector2(spawnX, spawnY + 0.5f), Quaternion.identity);
            }
        }
    }
}

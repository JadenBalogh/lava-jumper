using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleSystem : MonoBehaviour
{
    [SerializeField] private GameObject iciclePrefab;
    [SerializeField] private float spawnInterval = 30f;
    [SerializeField] private float spawnRangeX = 8f;
    [SerializeField] private float spawnY = 6;
    [SerializeField] private float spawnTick = 0.5f;
    [SerializeField] private int spawnCount = 5;

    private float spawnIntervalTimer = 0f;
    private float spawnTickTimer = 0f;
    private int currCount = 0;

    private void Update()
    {
        if (spawnIntervalTimer >= spawnInterval)
        {
            spawnTickTimer += Time.deltaTime;
            if (spawnTickTimer >= spawnTick)
            {
                spawnTickTimer = 0f;
                Instantiate(iciclePrefab, new Vector2(GameManager.Player.transform.position.x + Random.Range(-spawnRangeX, spawnRangeX), spawnY), Quaternion.identity);
                currCount++;
            }

            if (currCount >= spawnCount)
            {
                currCount = 0;
                spawnIntervalTimer = 0f;
            }
        }

        spawnIntervalTimer += Time.deltaTime;
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable] public class Wave{
        public GameObject enemyPrefab;
        public float spawnTimer;
        public float spawnInterval;
        public int enemiesPerwave;
        public int spawnedEnemyCount;
    }
    public List<Wave> waves;   
    public int waveNumber;
    public Transform minPos;
    public Transform maxPos;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameObject.activeSelf)
        {
            waves[waveNumber].spawnTimer += Time.deltaTime;
            if (waves[waveNumber].spawnTimer >= waves[waveNumber].spawnInterval)
            {
            waves[waveNumber].spawnTimer = 0;
            SpawnEnemy();
            }
            if (waves[waveNumber].spawnedEnemyCount >= waves[waveNumber].enemiesPerwave)
            {
                waves[waveNumber].spawnedEnemyCount = 0;
                if (waves[waveNumber].spawnInterval > 0.3f){
                    waves[waveNumber].spawnInterval *= 0.9f;
                }
                waveNumber++;
            }
            if (waveNumber >= waves.Count)
            {
                waveNumber = 0; 
            }
        }
    }
    private void SpawnEnemy()
    {
         Instantiate(waves[waveNumber].enemyPrefab, RandomPosition(), transform.rotation);
         waves[waveNumber].spawnedEnemyCount++;
    }
    private Vector2 RandomPosition()
    {
        Vector2 spawnPoint;
        if (Random.Range(0f, 1f) > 0.5 )
        {
            spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);
            if (Random.Range(0f, 1f)>0.5){
                spawnPoint.x = minPos.position.x;
            } else {
                spawnPoint.x = maxPos.position.x;
            }
        } else
        {
            spawnPoint.x = Random.Range(minPos.position.x, maxPos.position.x);
            if (Random.Range(0f, 1f)>0.5){
                spawnPoint.y = minPos.position.y;
            } else {
                spawnPoint.y = maxPos.position.y;
            }
        }   
        return spawnPoint;
    }
}

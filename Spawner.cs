using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public bool spawn = true;
    [SerializeField] float spawnTime;
    float tempSpawnTime;
    [SerializeField] float enemyUpgradingPerTime = 0.02f;
    
    float timeFromStart = 5;
    // Start is called before the first frame update
    void Start()
    {
        timeFromStart = 1 / 0.02f;
        InvokeRepeating("SpawnEnemy", 0, 2);
    }

    void Update()
    {
        
        if(spawnTime > 0.3f) spawnTime -= Time.deltaTime * 0.01f;
        timeFromStart += Time.deltaTime;
        if(tempSpawnTime > 0) tempSpawnTime -= Time.deltaTime;
        else
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    { 
        if(!spawn) return;
        tempSpawnTime = spawnTime; 
       Enemy enemyScript = Instantiate(enemy, RandomPosition(), Quaternion.identity).GetComponent<Enemy>();
       enemyScript.UpgradeEnemy(timeFromStart * enemyUpgradingPerTime);
    }
    
    Vector3 RandomPosition()
    {
        float random = Random.Range(0, 360);
        Vector2 temp = new Vector2(Mathf.Cos(random), Mathf.Sin(random) ) * 50;
        return new Vector3(temp.x, 1.5f, temp.y);
    }
}

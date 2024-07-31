using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] int enemiesCount = 1;
    [SerializeField] int enemiesToSpawn = 1;
    [SerializeField] GameObject enemy;

    PowerUpController powerUpController;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves();
        powerUpController = GameObject.Find("GameManager").GetComponent<PowerUpController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.instance.gameOver == false)
        {
            enemiesCount = FindObjectsOfType<Enemy>().Length;  //Find the remaining enemies
            if (enemiesCount == 0)
            {
                enemiesToSpawn++;  //Next wave: +1 enemy
                SpawnEnemyWaves();  //Spawns enemies
                SpawnPowerUp();  //Spawns a power up each wave
            }
        }
    }

    void SpawnEnemyWaves()
    {
        for (int i = 0; i < enemiesToSpawn; i++)  //Spawns all the enemies
        {
            Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);  //Spawns an enemy in a random position
        }

        Enemy _enemy = enemy.GetComponent<Enemy>();
        if (_enemy != null)
            _enemy.OnDie += SpawnEnemyWaves;
    }

    void SpawnPowerUp()
    {
        powerUpController.PowerUpToSpawn();

        if (powerUpController.hasPowerUp == false)
        {
            var i = powerUpController.powerUpNumber;
            Instantiate(powerUpController.powerUp[i], RandomSpawnPos(), powerUpController.powerUp[i].transform.rotation);  //Spawns a power up in a random position
        }
    }

    private Vector3 RandomSpawnPos()  //Random spawn position of the enemies
    {
        int posX = UnityEngine.Random.Range(-9, 9);
        int posY = UnityEngine.Random.Range(-4, 4);

        Vector3 spawnPos = new Vector3(posX, posY, 0);

        return spawnPos;
    }
}

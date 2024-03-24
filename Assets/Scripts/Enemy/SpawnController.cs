using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private int enemiesCount = 1;
    [SerializeField] private int enemiesToSpawn = 1;

    PowerUpController powerUpController;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves();
        powerUpController = GameObject.Find("GameManager").GetComponent<PowerUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DataController.instance.gameOver == false)
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
        var enemy = DataController.instance;

        for (int i = 0; i < enemiesToSpawn; i++)  //Spawns all the enemies
        {
            Instantiate(enemy.enemy, RandomSpawnPos(), enemy.enemy.transform.rotation);  //Spawns an enemy in a random position
        }

        Enemy _enemy = enemy.enemy.GetComponent<Enemy>();
        if (_enemy != null)
            _enemy.OnDie += SpawnEnemyWaves;
    }

    void SpawnPowerUp()
    {
        powerUpController.PowerUpToSpawn();

        var controller = DataController.instance;
        if (controller.hasPowerUp == false)
        {
            var i = controller.powerUpNumber;
            Instantiate(controller.powerUp[i], RandomSpawnPos(), controller.powerUp[i].transform.rotation);  //Spawns a power up in a random position
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

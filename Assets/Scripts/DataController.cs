using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public int playerSpeed = 10;  //Used in PlayerController.cs for speed and in SpawnController.cs for the power ups
    public int enemySpeed = 5;  //Used in Enemy.cs for the enemies speed
    public int weaponSpeed = 100;  //Used in WeaponController.cs and PlayerController.cs for the wapon speed
    public int powerUpNumber;  //Used in PowerUpController.cs and SpawnController.cs for having different types of power up
    public int healt = 100;  //Used in PowerUpController.cs and PlayerController.cs for the healt of the player
    public int enemiesDefeated;  //Used in Enemy.cs for counting how many enemies are defeated by the player

    public bool gameOver = false;  //Used in Enemy.cs, PlayerController.cs and SpawnController.cs  for staart or end the game
    public bool hasPowerUp = false;  //Used in SpawnController.cs and PlayerController.cs for use the power up

    public GameObject player;  //Used in Enemy.cs and Weapon.cs and SpawnController.cs
    public GameObject enemy;  //Used in SpawnController.cs
    public GameObject[] powerUp;  //Used in SpawnController.cs

    public TMP_Text wavesNumber;  //Used in PlayerController.cs
}

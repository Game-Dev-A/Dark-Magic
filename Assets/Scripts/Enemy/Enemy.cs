using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEnemy;

    public event Action OnDie = null;
    
    // Start is called before the first frame update
    void Start()
    {
        DataController.instance.player = GameObject.Find("Player");  //Set the position reference
    }

    // Update is called once per frame
    void Update()
    {
        if(DataController.instance.gameOver == false)
        {
            EnemyMovement();
        }
    }

    void EnemyMovement()
    {
        Vector3 distance = (DataController.instance.player.transform.position - transform.position);  //Direction of the movement
        transform.Translate(distance * DataController.instance.enemySpeed * Time.deltaTime * 0.01f);  //The movement
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Instantiate(deathEnemy, transform.position, Quaternion.identity);  //Spawn of the death enemy
            
            Destroy(gameObject);  //Death of the enemy
            if(OnDie != null)
                OnDie();

            var controller = DataController.instance;
            controller.enemiesDefeated++;
            controller.wavesNumber.text = "Enemies defeated: " + controller.enemiesDefeated;  //Keeps the number of waves defeated
        }
    }
}

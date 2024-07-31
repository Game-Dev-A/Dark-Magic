using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 playerPos;

    public int healt = 100;

    public UnityEvent OnPlayerDie = null;

    PowerUpController powerUpController;
    HealtBar healtBar;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUpController = GameObject.Find("GameManager").GetComponent<PowerUpController>();
        healtBar = GetComponent<HealtBar>();
        healtBar.SetMaxHealt(healt);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        playerPos.x = Input.GetAxisRaw("Horizontal");
        playerPos.y = Input.GetAxisRaw("Vertical");

        playerPos.Normalize();

        rb.position += playerPos * GameManager.instance.playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var controller = GameManager.instance;
        enemy = collision.GetComponentInParent<Enemy>(); 
        
        if (collision.gameObject.CompareTag("Enemy") && enemy.died == false)
        {
            healt -= enemy.Base.Attack;  //The player takes the damage

            healtBar.setHealt(healt);  //Update the healt

            if(healt <= 0)
            {
                Destroy(gameObject);  //K.O.

                if (OnPlayerDie != null)
                    OnPlayerDie.Invoke();

                controller.gameOver = true;  //The game ends
            }
        }
        else if (collision.gameObject.CompareTag("Power Up") && powerUpController.hasPowerUp == false)
        {
            Destroy(collision.gameObject);  //This destroy the power up

            powerUpController.hasPowerUp = true;  //The player can't keep another power up
            powerUpController.PowerUpAbility();  //The player ability are upgreaded

            StartCoroutine(powerUpController.PowerUpTimerRutine());  //The player ability are resetted
        }
    }
}
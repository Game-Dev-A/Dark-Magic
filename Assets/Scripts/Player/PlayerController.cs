using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 playerPos;

    public UnityEvent OnPlayerDie = null;

    PowerUpController powerUpController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUpController = GameObject.Find("GameManager").GetComponent<PowerUpController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        playerPos.x = Input.GetAxisRaw("Horizontal");
        playerPos.y = Input.GetAxisRaw("Vertical");

        playerPos.Normalize();

        rb.position += playerPos * DataController.instance.playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var controller = DataController.instance;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            controller.healt -= 25;
            if(controller.healt <= 0)
            {
                Destroy(gameObject);  //K.O.

                if (OnPlayerDie != null)
                    OnPlayerDie.Invoke();

                controller.gameOver = true;  //The game ends
            }
        }
        else if (collision.gameObject.CompareTag("Power Up") && controller.hasPowerUp == false)
        {
            Destroy(collision.gameObject);  //This destroy the power up

            controller.hasPowerUp = true;  //The player can't keep another power up
            
            powerUpController.PowerUpAbility();

            StartCoroutine(powerUpController.PowerUpTimerRutine());
        }
    }
}
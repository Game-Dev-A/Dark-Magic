using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 playerPos;

    public UnityEvent OnPlayerDie = null;

    PowerUpController powerUpController;

    HealtBar healtBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUpController = GameObject.Find("GameManager").GetComponent<PowerUpController>();
        healtBar = GetComponent<HealtBar>();
        healtBar.SetMaxHealt(DataController.instance.healt);
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

        rb.position += playerPos * DataController.instance.playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var controller = DataController.instance;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            controller.healt -= 25;

            healtBar.setHealt(controller.healt);

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
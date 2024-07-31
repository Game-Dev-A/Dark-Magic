using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    HealtBar healtBar;
    PlayerController playerController;

    public GameObject[] powerUp;

    public bool hasPowerUp;
    public int powerUpNumber;
    // Start is called before the first frame update
    void Start()
    {
        healtBar = GameObject.Find("Player").GetComponent<HealtBar>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PowerUpToSpawn()  //Which power up is spawned
    {
        int powerUpNumb = Random.Range(1, 100);

        if (powerUpNumb >= 1 && powerUpNumb <= 36)
            powerUpNumber = 0;
        else if (powerUpNumb >= 37 && powerUpNumb <= 68)
            powerUpNumber = 1;
        else if(powerUpNumb >= 69 && powerUpNumb <= 90)
            powerUpNumber = 2;
        else if(powerUpNumb >= 91 && powerUpNumb <=100)
            powerUpNumber = 3;
    }

    public void PowerUpAbility()
    {
        var controller = GameManager.instance;

        switch (powerUpNumber)
        {
            case 0:
                playerController.healt += 25;  //Augment the player healt
                healtBar.setHealt(playerController.healt);  //Update the healt bar
                break;
            case 1:
                controller.playerSpeed += 5;  //Augment the player speed
                break;
            case 2:
                controller.weaponSpeed += 40;  //Augment the player's weapon speed
                break;
            case 3:
                playerController.healt += 35;  //Augment the player healt
                controller.playerSpeed += 5;  //Augment the player speed
                controller.weaponSpeed += 40;  //Augment the player's weapon speed
                healtBar.setHealt(playerController.healt);  //Update the healt bar
                break;
            default:
                controller.playerSpeed = 10;
                controller.weaponSpeed = 100;
                break;
        }
    }

    public IEnumerator PowerUpTimerRutine()
    { 
        yield return new WaitForSeconds(5);

        var controller = GameManager.instance;
        hasPowerUp = false;  //The player can keep another power up now

        switch (powerUpNumber)
        {
            case 0:
                playerController.healt += 0;  //The player healt remain equal
                break;
            case 1:
                controller.playerSpeed -= 5;  //The player speed is resetted
                break;
            case 2:
                controller.weaponSpeed -= 40;  //The player's weapon speed is resetted
                break;
            case 3:
                playerController.healt -= 35;  //The player healt is resetted
                controller.playerSpeed -= 5;  //The player speed is resetted
                controller.weaponSpeed -= 40;  //The player's weapon speed is resetted
                break;
            default:
                controller.playerSpeed = 10;
                controller.weaponSpeed = 100;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PowerUpToSpawn()  //Which power up is spawned
    {
        int powerUpNumb = Random.Range(1, 100);

        if (powerUpNumb >= 1 && powerUpNumb <= 36)
            DataController.instance.powerUpNumber = 0;
        else if (powerUpNumb >= 37 && powerUpNumb <= 68)
            DataController.instance.powerUpNumber = 1;
        else if(powerUpNumb >= 69 && powerUpNumb <= 90)
            DataController.instance.powerUpNumber = 2;
        else if(powerUpNumb >= 91 && powerUpNumb <=100)
            DataController.instance.powerUpNumber = 3;
    }

    public void PowerUpAbility()
    {
        var controller = DataController.instance;

        switch (controller.powerUpNumber)
        {
            case 0:
                controller.healt += 25;  //Augment the player healt
                break;
            case 1:
                controller.playerSpeed += 5;  //Augment the player speed
                break;
            case 2:
                controller.weaponSpeed += 40;  //Augment the player's weapon speed
                break;
            case 3:
                controller.healt += 35;  //Augment the player healt
                controller.playerSpeed += 8;  //Augment the player speed
                controller.weaponSpeed += 50;  //Augment the player's weapon speed
                break;
        }
    }

    public IEnumerator PowerUpTimerRutine()
    { 
        yield return new WaitForSeconds(5);

        var controller = DataController.instance;
        controller.hasPowerUp = false;  //The player can keep another power up now

        switch (controller.powerUpNumber)
        {
            case 0:
                controller.healt -= 25;  //The player healt is resetted
                break;
            case 1:
                controller.playerSpeed -= 5;  //The player speed is resetted
                break;
            case 2:
                controller.weaponSpeed -= 40;  //The player's weapon speed is resetted
                break;
            case 3:
                controller.healt -= 35;  //The player healt is resetted
                controller.playerSpeed -= 8;  //The player speed is resetted
                controller.weaponSpeed -= 50;  //The player's weapon speed is resetted
                break;
        }
    }
}

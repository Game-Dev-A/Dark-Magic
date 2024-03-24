using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(DataController.instance.player.transform.position, Vector3.forward, DataController.instance.weaponSpeed * Time.deltaTime);  //The weapon rotate around the player
    }
}
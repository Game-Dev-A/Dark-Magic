using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsController : MonoBehaviour
{
    [SerializeField] private Transform[] clouds = new Transform[6];
    [SerializeField] private float cloudsSpeed = 10f;
    [SerializeField] private float maxPosX = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < clouds.Length; i++)
        {
            clouds[i].position = clouds[i].position + Vector3.right * cloudsSpeed * Time.deltaTime;  //Movement to right of the clouds

            if (clouds[i].position.x > maxPosX)
                clouds[i].position -= new Vector3(maxPosX * 2, 0, 0);  //Reset of the position
        }
    }
}
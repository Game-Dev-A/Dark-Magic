using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy this object after 5 seconds
        Invoke(nameof(DestroyObject), 5);
    }

    private void DestroyObject()
    {
        //Removes the object from our Scene
        Destroy(gameObject);
    }
}

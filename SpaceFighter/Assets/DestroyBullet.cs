using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public GameObject ship;
    private float maxRadius = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ship != null)
        {
            if(Math.Abs((ship.transform.position - gameObject.transform.position).magnitude) > maxRadius)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

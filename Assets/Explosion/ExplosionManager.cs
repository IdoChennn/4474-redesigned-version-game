using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    float timer;
    float explosionExpireTimer;
    // Start is called before the first frame update
    void Start()
    {
        explosionExpireTimer = 5;
        timer = explosionExpireTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

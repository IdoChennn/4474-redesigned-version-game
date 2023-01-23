using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeliController : MonoBehaviour
{
    Rigidbody heliBody;
    GameObject playerObject;
    public GameObject missileObject;
    public GameObject missilePort;
    float fireRate;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        heliBody = gameObject.GetComponent<Rigidbody>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        fireRate = 6;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (playerObject != null)
        {
            float dist = Vector3.Distance(playerObject.transform.position, transform.position);
            if (dist < 200)
            {
                if (timer > fireRate)
                {
                    FireMissile();
                    timer = 0;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (playerObject != null)
        {
            transform.LookAt(playerObject.transform);
            heliBody.AddRelativeForce(0, 0, 5);
        }
    }

    void FireMissile()
    {
        Instantiate(missileObject, missilePort.transform.position, missilePort.transform.rotation);
    }
}

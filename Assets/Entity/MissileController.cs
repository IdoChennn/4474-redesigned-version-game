using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissileController : MonoBehaviour
{
    public GameObject explosionObject;
    Rigidbody missileBody;
    float damage;
    float timer;
    float safeTime;
    float selfExplodeTimer;
    // Start is called before the first frame update
    void Start()
    {
        damage = 90;
        missileBody = gameObject.transform.GetComponent<Rigidbody>();
        missileBody.drag = 10;
        selfExplodeTimer = 10;
        safeTime = 0.5f;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > selfExplodeTimer)
        {
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        missileBody.AddRelativeForce(0, 0, 1000);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timer > safeTime)
        {
            if (other != null && other.attachedRigidbody.gameObject.GetComponent<HealthManager>() != null)
            {
                Debug.Log("Hit");
                other.attachedRigidbody.gameObject.GetComponent<HealthManager>().ReduceHP(damage);
            }
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

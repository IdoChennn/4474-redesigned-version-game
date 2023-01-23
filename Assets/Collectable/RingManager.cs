using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public GameObject nextRing;
    public bool isStartingRing;
    // Start is called before the first frame update
    void Start()
    {
        if (!isStartingRing)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            if (nextRing != null)
            {
                nextRing.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}

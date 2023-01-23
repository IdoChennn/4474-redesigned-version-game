using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject missileObject;
    public GameObject pauseManagerObject;
    PauseManager pauseManager;
    float timer;
    float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        pauseManager = pauseManagerObject.GetComponent<PauseManager>();
        fireRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer > fireRate && !pauseManager.GetIsPaused())
        {
            Instantiate(missileObject, transform.position, transform.rotation);
            timer = 0;
        }
    }
}

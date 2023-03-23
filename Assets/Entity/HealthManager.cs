using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject explosionObject;
    public GameObject upgradeManagerObject;
    UpgradeManager upgradeManager;
    public bool isPlayer;
    float healthPoint;
    float maxHP;
    // Start is called before the first frame update
    void Start()
    {
     
        if (isPlayer)
        {
            upgradeManager = upgradeManagerObject.GetComponent<UpgradeManager>();
            upgradeManager.LoadData();
            maxHP = upgradeManager.GetHP();
        }
        else
        {
            maxHP = 100;
        }
        healthPoint = maxHP;
    }

    private void Update()
    {
        if (healthPoint <= 0)
        {
            Instantiate(explosionObject, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    public float GetHP()
    {
        return healthPoint;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }

    public void ReduceHP(float amount)
    {
        healthPoint -= amount;
        if(healthPoint < 0)
        {
            healthPoint = 0;
        }
    }

    public void InstantDeath()
    {
        healthPoint = 0;
    }

    public void SetHP(float amount)
    {
        healthPoint = amount;
    }

    public void AddHP(float amount)
    {
        healthPoint += amount;
        if(healthPoint > maxHP)
        {
            healthPoint = maxHP;
        }
    }

    public void SetMaxHP(float amount)
    {
        maxHP = amount;
    }
}

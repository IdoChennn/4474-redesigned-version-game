using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    HealthManager playerHealthManager;
    TMP_Text healthUI;
    void Start()
    {
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        healthUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = playerHealthManager.GetHP().ToString("F0");
    }
}

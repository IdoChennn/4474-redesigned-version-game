using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUI : MonoBehaviour
{
    PlayerController playerController;
    TMP_Text speedUI;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        speedUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedUI.text = (playerController.GetSpeed()*10).ToString("F0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrottlePercentage : MonoBehaviour
{
    PlayerController playerController;
    TMP_Text heightNum;
    float percentNum;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        heightNum = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        percentNum = playerController.GetThrottlePower() * 100;
        heightNum.text = percentNum.ToString("F0");
    }
}

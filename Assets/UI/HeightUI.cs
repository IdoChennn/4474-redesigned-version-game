using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeightUI : MonoBehaviour
{
    PlayerController playerController;
    TMP_Text heightUI;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        heightUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        heightUI.text = playerController.GetHeight().ToString("F0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThorttleUIManager : MonoBehaviour
{
    PlayerController playerController;
    Scrollbar throttleUI;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        throttleUI = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        throttleUI.value = playerController.GetThrottlePower();
    }
}

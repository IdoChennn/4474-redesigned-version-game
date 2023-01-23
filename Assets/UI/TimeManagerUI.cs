using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManagerUI : MonoBehaviour
{
    public GameObject gameManagerObject;
    TMP_Text timeUI;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        timeUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeUI.text = gameManager.getGameTime().ToString("F2");
    }
}

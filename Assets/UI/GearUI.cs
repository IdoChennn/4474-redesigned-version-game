using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GearUI : MonoBehaviour
{
    Animator gearAnimator;
    TMP_Text gearUI;

    // Start is called before the first frame update
    void Start()
    {
        gearAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        gearUI = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gearAnimator.GetBool("GearToggle"))
        {
            gearUI.color = Color.red;
        } else
        {
            gearUI.color = Color.green;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthManager healthManager;
    Slider thisSlider;
    // Start is called before the first frame update
    void Start()
    {
        thisSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        thisSlider.maxValue = healthManager.GetMaxHP();
        thisSlider.minValue = 0;
        thisSlider.value = healthManager.GetHP();
    }
}

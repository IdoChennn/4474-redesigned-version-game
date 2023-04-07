using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XAxis : MonoBehaviour
{
    Slider thisSlider;
    // Start is called before the first frame update
    void Start()
    {
        thisSlider = GetComponent<Slider>();
        thisSlider.maxValue = 0.5f;
        thisSlider.minValue = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        thisSlider.value = (Input.mousePosition.x - Screen.width / 2) / Screen.width;
    }
}

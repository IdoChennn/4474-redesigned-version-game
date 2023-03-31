using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    private Button button;

    public Color selectedColor;

    void Start()
    {
        button = GetComponent<Button>();
        ColorBlock colors = button.colors;
        colors.highlightedColor = selectedColor;
        colors.pressedColor = selectedColor;
        button.colors = colors;
    }
}
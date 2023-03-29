using UnityEngine;
using UnityEngine.UI;

public class SetBackgroundImage : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite image;

    private void Start()
    {
        backgroundImage.sprite = image;
        backgroundImage.preserveAspect = true;
        backgroundImage.SetNativeSize();
    }
}
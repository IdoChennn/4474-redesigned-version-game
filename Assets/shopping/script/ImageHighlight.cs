using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // The original color of the image
    private Color originalColor;

    // The color to change the image to when highlighted
    public Color highlightColor;

    // The image component
    private Image image;

    private void Start()
    {
        // Get the image component
        image = GetComponent<Image>();

        // Save the original color of the image
        originalColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the color of the image to the highlight color
        image.color = highlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the color of the image to the original color
        image.color = originalColor;
    }
}

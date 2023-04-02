using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D cursorTexture; // The texture you want to use for the cursor
    public Vector2 hotSpot = new(12, 5); // The hotspot of the cursor (default is center of image)
    GameObject cameraObject;
    AudioSource mouseEnterEffect;
    AudioSource buttonClickEffect;
    Button thisButton;
    Toggle thisToggle;

    private void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        mouseEnterEffect = cameraObject.GetComponent<AudioSource>();
        buttonClickEffect = GameObject.FindGameObjectWithTag("ButtonClickSound").GetComponent<AudioSource>();
        thisButton = gameObject.GetComponent<Button>();
        if(thisButton != null)
        {
            thisButton.onClick.AddListener(ButtonClicked);
        }
        thisToggle = gameObject.GetComponent<Toggle>();
        if(thisToggle != null)
        {
            thisToggle.onValueChanged.AddListener((delegate {
                ToggleClicked(); }));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        mouseEnterEffect.Play();
    }

    public void ButtonClicked()
    {
        buttonClickEffect.Play();
    }

    public void ToggleClicked()
    {
        buttonClickEffect.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
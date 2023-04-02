using UnityEngine;

public class CameraCanvasCapture : MonoBehaviour
{
    public Camera camera;
    public RectTransform canvasRectTransform;

    private void Start()
    {
        camera.rect = new Rect(0, 0, canvasRectTransform.rect.width, canvasRectTransform.rect.height);
    }
}

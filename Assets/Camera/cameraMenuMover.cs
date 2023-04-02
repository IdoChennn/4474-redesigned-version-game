using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class cameraMenuMover : MonoBehaviour
{

    public Vector3 initialPosition;
    public Quaternion initialRotation;
    public float duration = 1f;
    public AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    public void MoveCamera(string buttonIdentifier)

    {
        Vector3 newPosition;
        Quaternion newRotation;

        switch (buttonIdentifier)
        {
            case "Campaign":
                newPosition = new Vector3(292f, 2.261f, 167f);
                newRotation = Quaternion.Euler(7.873002f, 90f, 0f);
                break;
            case "Online":
                newPosition = new Vector3(350f, 5f, 167f);
                newRotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case "Achievement":
                newPosition = new Vector3(350f, 5f, 167f);
                newRotation = Quaternion.Euler(0f, 0f, 0f);
                break;

            // Add more cases for each button
            default:
                newPosition = initialPosition;
                newRotation = initialRotation;
                break;
        }

        StartCoroutine(MoveCameraCoroutine(newPosition, newRotation));
    }
    private IEnumerator MoveCameraCoroutine(Vector3 position, Quaternion rotation)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float time = 0f;

        while (time < duration)
        {
            float t = curve.Evaluate(time / duration);

            transform.position = Vector3.Lerp(startPos, position, t);
            transform.rotation = Quaternion.Lerp(startRot, rotation, t);

            time += Time.deltaTime;
            yield return null;
        }

        transform.position = position;
        transform.rotation = rotation;
    }
    public void BackToPreviousPosition()
    {

        StartCoroutine(MoveCameraCoroutine(initialPosition, initialRotation));
    }
}

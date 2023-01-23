using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject thirdPersonEmpty;
    public GameObject firstPersonEmpty;
    public GameObject gameManagerObject;
    int cameraToggle;
    int numOfViews;
    // Start is called before the first frame update
    void Start()
    {
        cameraToggle = 1;
        numOfViews = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (thirdPersonEmpty != null)
        {
            if (cameraToggle == 1)
            {
                transform.position = thirdPersonEmpty.transform.position;
                transform.rotation = thirdPersonEmpty.transform.rotation;
                transform.localScale = thirdPersonEmpty.transform.localScale;
            }
            else if (cameraToggle == 2)
            {
                transform.position = firstPersonEmpty.transform.position;
                transform.rotation = firstPersonEmpty.transform.rotation;
                transform.localScale = firstPersonEmpty.transform.localScale;
            }
            else
            {
                transform.position = thirdPersonEmpty.transform.position;
                transform.rotation = thirdPersonEmpty.transform.rotation;
                transform.localScale = thirdPersonEmpty.transform.localScale;
            }
            if (Input.GetButtonDown("Camera Toggle"))
            {
                cameraToggle++;
            }
            if (cameraToggle > numOfViews)
            {
                cameraToggle = 1;
            }
        }
    }
}

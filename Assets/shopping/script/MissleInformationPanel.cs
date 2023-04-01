using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class MissleInformationPanel : MonoBehaviour, IPointerClickHandler
{

    public GameObject missilePanel;
    public GameObject missileInfomationPanel;
    public GameObject barPrefab;
    public Vector2 startPosition;
    public float maxHeight;
    //public Text labelPrefab;
    private void disableAll()
    {
        List<GameObject> objectList = new List<GameObject>();
        objectList.Add(missilePanel);
        objectList.Add(missileInfomationPanel);
        foreach (GameObject objs in objectList)
        {
            // Check if the object was found
            if (objs != null)
            {
                // Do something with the object, such as enabling it or accessing its components
                objs.SetActive(false);
            }
            else
            {
                // Display an error message if the object was not found
                Debug.LogError("Could not find object");
            }
        }

        try {
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");



            // loop through all clones and destroy them
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }
        catch (UnityException){ 

        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        disableAll();
        missileInfomationPanel.SetActive(true);
        generateBarChart(new float[] {100,90,90, 85, 90});


        // Get the GameObject that was clicked on
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        // Get the Image component of the clicked GameObject
        Image clickedImage = clickedObject.GetComponent<Image>();

        // Check if an Image component was found
        if (clickedImage != null)
        {
            Debug.Log("Image " + clickedImage.name + " was clicked!");
        }
        else
        {
            Debug.Log("No Image component was found on the clicked GameObject.");
        }
    }

    private void generateBarChart(float[] barHeights)
    {
        
        Color barColor = Color.white;
        float barWidth = 50f;
        float barSpacing = 10f;

        //Vector2 startPosition = new Vector2(-1400,360);
        for (int i = 0; i < barHeights.Length; i++)
        {
            // Create a new bar
            GameObject bar = Instantiate(barPrefab);
            bar.tag = "Clone";

            // Set the bar's height
            float height = barHeights[i] / maxHeight;
            bar.GetComponent<RectTransform>().sizeDelta = new Vector2(barWidth, height * maxHeight);

            // Set the bar's position
            float x = startPosition.x + i * (barWidth + barSpacing);
            float y = startPosition.y + height * maxHeight / 2f;

            bar.GetComponent<RectTransform>().position = new Vector3(x, y);

            // Set the bar's color
            bar.GetComponent<Image>().color = barColor;

            // Set the bar's parent to this transform
            bar.transform.SetParent(barPrefab.transform);
        }
    }
        
}


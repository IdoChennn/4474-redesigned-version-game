using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campaiginSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject campaignSelect;
    public GameObject episode1;
    public GameObject episode2;
    public GameObject episode3;
    public GameObject goBackButton;

    public void enableCampaignSelectWindow()
    {
        episode1.SetActive(false);
        episode2.SetActive(false);
        episode3.SetActive(false);
        campaignSelect.SetActive(true);
    }

    public void clickGoBack()
    {
        episode1.SetActive(true);
        episode2.SetActive(true);
        episode3.SetActive(true);
        campaignSelect.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

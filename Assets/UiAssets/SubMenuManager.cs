using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SubMenuManager : MonoBehaviour
{
    public GameObject CampaignSub;
    public GameObject OnlineSub;
    public GameObject CampaignMenu;
    public GameObject OnlineMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disableAll()
    {
        foreach (Transform child in CampaignMenu.transform)
        {

                child.gameObject.SetActive(false);
            
        }
    }

    public void enablePage(string buttonName)
    {
        disableAll();
        Transform pageTrans = CampaignMenu.transform.Find(buttonName);
        GameObject pageObj = pageTrans.gameObject;
        pageObj.SetActive(true);
    }

    
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hightlightButtons : MonoBehaviour
{
    public Button HomeButton;
    public Button CampaignButton;
    public Button OnlineButton;
    public Button SettingButton;
    public Button AchievementButton;
    public Button TurorialButton;
    public Button QuitButton;

    public Color newColor;
    public Color oldColor;
    private List<Button> buttonList;
   

    public void updataButtonColor(string buttonName)
    {
        buttonList = new List<Button>();
        buttonList.Add(CampaignButton);
        buttonList.Add(OnlineButton);
        buttonList.Add(SettingButton);
        buttonList.Add(AchievementButton);
        buttonList.Add(TurorialButton);
        buttonList.Add(QuitButton);
        buttonList.Add(HomeButton);


        foreach(Button button in buttonList)
        {
            if (button.name == buttonName && buttonName != "Home")
            {
                ColorBlock colors = button.colors;
                colors.normalColor = newColor;
                button.colors = colors;
            }
           
            else
            {
                ColorBlock colors = button.colors;
                colors.normalColor = oldColor;
                button.colors = colors;
            }
        }

    }
}
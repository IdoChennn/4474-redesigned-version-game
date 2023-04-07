using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusUpdate : MonoBehaviour
{
    public TextMeshProUGUI moneyComponent;
    public TextMeshProUGUI enginePowerComponent;
    public TextMeshProUGUI maneuverabilityComponent;
    public TextMeshProUGUI hpComponent;

    public void updateMoney(string money) {
        moneyComponent.text = money;
    }
    public void updateEngine(string money) {
        string temp = enginePowerComponent.text;
        float result = float.Parse(temp) + float.Parse(money);
        enginePowerComponent.text = result.ToString();
    }
    public void updateManeuverability(string money) {
        maneuverabilityComponent.text += money;
    }
    public void updateHP(string money) {
        hpComponent.text += money;
    }




}

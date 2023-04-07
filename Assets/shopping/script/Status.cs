using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    public TextMeshProUGUI moneyComponent;
    public TextMeshProUGUI enginePowerComponent;
    public TextMeshProUGUI maneuverabilityComponent;
    public TextMeshProUGUI hpComponent;
    public string fileName;
    float defaultMoney;
    float defaultEnginePower;
    float defaultPitchPower;
    float defaultMaxPitch;
    float defaultYawPower;
    float defaultMaxYaw;
    float defaultRollPower;
    float defaultMaxRoll;
    float enginePowerIncrement;
    float stickPowerIncrement;
    float rudderPowerIncrement;
    float maxIncrement;

    float defaultHP;
    float hpIncrement;

    float money;
    float enginePower;
    float pitchPower;
    float maxPitch;
    float yawPower;
    float maxYaw;
    float rollPower;
    float maxRoll;
    float hp;

    float enginePowerCost;
    float maneuverabilityCost;
    float hpCost;


    void Start()
    {

       
        // Get the path of the text file
        //string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        //// Read the text from the file
        //string fileText = "";
      
        string upgradeFileName = "upgrade.txt";
        defaultMoney = 2000;
        defaultEnginePower = 15;
        defaultPitchPower = 0.15f;
        defaultMaxPitch = 4;
        defaultYawPower = 0.045f;
        defaultMaxYaw = 3;
        defaultRollPower = 0.15f;
        defaultMaxRoll = 4;
        enginePowerIncrement = 1;
        stickPowerIncrement = 0.01f;
        rudderPowerIncrement = 0.001f;
        maxIncrement = 0.1f;
        defaultHP = 100;
        hpIncrement = 10;
        enginePowerCost = 1000;
        maneuverabilityCost = 1000;
        hpCost = 500;
        if (File.Exists(upgradeFileName))
        {
            StreamReader reader = File.OpenText(upgradeFileName);
            money = float.Parse(reader.ReadLine());
            enginePower = float.Parse(reader.ReadLine());
            Debug.Log(enginePower);
            if (enginePower == 0)
            {
                enginePower = defaultEnginePower;
                Debug.Log(enginePower);
            }
            pitchPower = float.Parse(reader.ReadLine());
            if (pitchPower == 0)
            {
                pitchPower = defaultPitchPower;
            }
            maxPitch = float.Parse(reader.ReadLine());
            if (maxPitch == 0)
            {
                maxPitch = defaultMaxPitch;
            }
            yawPower = float.Parse(reader.ReadLine());
            if (yawPower == 0)
            {
                yawPower = defaultYawPower;
            }
            maxYaw = float.Parse(reader.ReadLine());
            if (maxYaw == 0)
            {
                maxYaw = defaultMaxYaw;
            }
            rollPower = float.Parse(reader.ReadLine());
            if (rollPower == 0)
            {
                rollPower = defaultRollPower;
            }
            maxRoll = float.Parse(reader.ReadLine());
            if (maxRoll == 0)
            {
                maxRoll = defaultMaxRoll;
            }
            hp = float.Parse(reader.ReadLine());
            if (hp == 0)
            {
                hp = defaultHP;
            }
            reader.Close();
        }

        // Update the text component with the file contents
        enginePowerComponent.text = enginePower.ToString();
        moneyComponent.text = "999,999,999";
        maneuverabilityComponent.text = "100";
        hpComponent.text = hpIncrement.ToString();
    }

    public void updateAircraft() { }
}

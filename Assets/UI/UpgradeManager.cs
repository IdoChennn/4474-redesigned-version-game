using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public GameObject enginePowerLevelObject;
    TMP_Text enginePowerLevel;
    public GameObject maneuverabilityLevelObject;
    TMP_Text maneuverabilityLevel;
    public GameObject hpLevelObject;
    TMP_Text hpLevel;
    public GameObject moneyObject;
    TMP_Text moneyUI;
    float enginePowerLevelFloat;
    float maneuverabilityLevelFloat;
    float hpLevelFloat;

    string upgradeFileName;

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

    // Start is called before the first frame update
    void Start()
    {
        if (enginePowerLevelObject != null)
        {
            enginePowerLevel = enginePowerLevelObject.GetComponent<TMP_Text>();
            maneuverabilityLevel = maneuverabilityLevelObject.GetComponent<TMP_Text>();
            hpLevel = hpLevelObject.GetComponent<TMP_Text>();
            moneyUI = moneyObject.GetComponent<TMP_Text>();
        }
        upgradeFileName = "upgrade.txt";
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
            if(enginePower == 0)
            {
                enginePower = defaultEnginePower;
                Debug.Log(enginePower);
            }
            pitchPower = float.Parse(reader.ReadLine());
            if(pitchPower == 0)
            {
                pitchPower = defaultPitchPower;
            }
            maxPitch = float.Parse(reader.ReadLine());
            if(maxPitch == 0)
            {
                maxPitch = defaultMaxPitch;
            }
            yawPower = float.Parse(reader.ReadLine());
            if(yawPower == 0)
            {
                yawPower = defaultYawPower;
            }
            maxYaw = float.Parse(reader.ReadLine());
            if(maxYaw == 0)
            {
                maxYaw = defaultMaxYaw;
            }
            rollPower = float.Parse(reader.ReadLine());
            if(rollPower == 0)
            {
                rollPower = defaultRollPower;
            }
            maxRoll = float.Parse(reader.ReadLine());
            if(maxRoll == 0)
            {
                maxRoll = defaultMaxRoll;
            }
            hp = float.Parse(reader.ReadLine());
            if(hp == 0)
            {
                hp = defaultHP;
            }
            reader.Close();
        } else
        {
            StreamWriter writer = File.AppendText(upgradeFileName);
            writer.WriteLine(defaultMoney);
            money = defaultMoney;
            writer.WriteLine(defaultEnginePower);
            enginePower = defaultEnginePower;
            writer.WriteLine(defaultPitchPower);
            pitchPower = defaultPitchPower;
            writer.WriteLine(defaultMaxPitch);
            maxPitch = defaultMaxPitch;
            writer.WriteLine(defaultYawPower);
            yawPower = defaultYawPower;
            writer.WriteLine(defaultMaxYaw);
            maxYaw = defaultMaxYaw;
            writer.WriteLine(defaultRollPower);
            rollPower = defaultRollPower;
            writer.WriteLine(defaultMaxRoll);
            maxRoll = defaultMaxRoll;
            writer.WriteLine(defaultHP);
            hp = defaultHP;
            writer.Close();
        }
    }

    public void LoadData()
    {
        if (enginePowerLevelObject != null)
        {
            enginePowerLevel = enginePowerLevelObject.GetComponent<TMP_Text>();
            maneuverabilityLevel = maneuverabilityLevelObject.GetComponent<TMP_Text>();
            hpLevel = hpLevelObject.GetComponent<TMP_Text>();
            moneyUI = moneyObject.GetComponent<TMP_Text>();
        }
        upgradeFileName = "upgrade.txt";
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
        else
        {
            StreamWriter writer = File.AppendText(upgradeFileName);
            writer.WriteLine(defaultMoney);
            money = defaultMoney;
            writer.WriteLine(defaultEnginePower);
            enginePower = defaultEnginePower;
            writer.WriteLine(defaultPitchPower);
            pitchPower = defaultPitchPower;
            writer.WriteLine(defaultMaxPitch);
            maxPitch = defaultMaxPitch;
            writer.WriteLine(defaultYawPower);
            yawPower = defaultYawPower;
            writer.WriteLine(defaultMaxYaw);
            maxYaw = defaultMaxYaw;
            writer.WriteLine(defaultRollPower);
            rollPower = defaultRollPower;
            writer.WriteLine(defaultMaxRoll);
            maxRoll = defaultMaxRoll;
            writer.WriteLine(defaultHP);
            hp = defaultHP;
            writer.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enginePowerLevelObject != null)
        {
            enginePowerLevelFloat = (enginePower - defaultEnginePower) / enginePowerIncrement;
            enginePowerLevel.text = enginePowerLevelFloat.ToString("F0");
            maneuverabilityLevelFloat = (pitchPower - defaultPitchPower) / stickPowerIncrement;
            maneuverabilityLevel.text = maneuverabilityLevelFloat.ToString("F0");
            hpLevelFloat = (hp - defaultHP) / hpIncrement;
            hpLevel.text = hpLevelFloat.ToString("F0");
            moneyUI.text = money.ToString("F0");
        }
    }

    public void IncreaseEnginePower()
    {
        if(money >= enginePowerCost && enginePowerLevelFloat < 10)
        {
            money -= enginePowerCost;
            enginePower += enginePowerIncrement;
        }
    }

    public void DecreaseEnginePower()
    {
        if(enginePowerLevelFloat > 0)
        {
            enginePower -= enginePowerIncrement;
            money += enginePowerCost;
        }
    }

    public void IncreaseManeuverability()
    {
        if(money >= maneuverabilityCost && maneuverabilityLevelFloat < 10)
        {
            money -= maneuverabilityCost;
            pitchPower += stickPowerIncrement;
            maxPitch += maxIncrement;
            yawPower += rudderPowerIncrement;
            maxYaw += maxIncrement;
            rollPower += stickPowerIncrement;
            maxRoll += maxIncrement;

        }
    }

    public void DecreaseManeuverability()
    {
        if(maneuverabilityLevelFloat > 0)
        {
            money += maneuverabilityCost;
            pitchPower -= stickPowerIncrement;
            maxPitch -= maxIncrement;
            yawPower -= rudderPowerIncrement;
            maxYaw -= maxIncrement;
            rollPower -= stickPowerIncrement;
            maxRoll -= maxIncrement;
        }
    }

    public void IncreaseHP()
    {
        if(money >= hpCost && hpLevelFloat < 10)
        {
            money -= hpCost;
            hp += hpIncrement;
        }
    }

    public void DecreaseHP()
    {
        if(hpLevelFloat > 0)
        {
            money += hpCost;
            hp -= hpIncrement;
        }
    }

    private void ClearFile(string fileName)
    {
        File.WriteAllText(fileName, "");
    }

    public void ClickApply()
    {
        if (File.Exists(upgradeFileName))
        {
            ClearFile(upgradeFileName);
            StreamWriter writer = File.AppendText(upgradeFileName);
            writer.WriteLine(money);
            writer.WriteLine(enginePower);
            writer.WriteLine(pitchPower);
            writer.WriteLine(maxPitch);
            writer.WriteLine(yawPower);
            writer.WriteLine(maxYaw);
            writer.WriteLine(rollPower);
            writer.WriteLine(maxRoll);
            writer.WriteLine(hp);
            writer.Close();
        } else
        {
            StreamWriter writer = File.AppendText(upgradeFileName);
            writer.WriteLine(money);
            writer.WriteLine(enginePower);
            writer.WriteLine(pitchPower);
            writer.WriteLine(maxPitch);
            writer.WriteLine(yawPower);
            writer.WriteLine(maxYaw);
            writer.WriteLine(rollPower);
            writer.WriteLine(maxRoll);
            writer.WriteLine(hp);
            writer.Close();
        }
    }

    public void AddMoney(float amount)
    {
        if(amount < 0)
        {
            amount = 0;
        }
        money += amount;
        if (File.Exists(upgradeFileName))
        {
            ClearFile(upgradeFileName);
            StreamWriter writer = File.AppendText(upgradeFileName);
            writer.WriteLine(money);
            writer.WriteLine(enginePower);
            writer.WriteLine(pitchPower);
            writer.WriteLine(maxPitch);
            writer.WriteLine(yawPower);
            writer.WriteLine(maxYaw);
            writer.WriteLine(rollPower);
            writer.WriteLine(maxRoll);
            writer.WriteLine(hp);
            writer.Close();
        }
        else
        {
            StreamWriter writer = File.AppendText(upgradeFileName);
            writer.WriteLine(money);
            writer.WriteLine(enginePower);
            writer.WriteLine(pitchPower);
            writer.WriteLine(maxPitch);
            writer.WriteLine(yawPower);
            writer.WriteLine(maxYaw);
            writer.WriteLine(rollPower);
            writer.WriteLine(maxRoll);
            writer.WriteLine(hp);
            writer.Close();
        }
    }

    public float GetEnginePower()
    {
        return enginePower;
    }

    public float GetMoney()
    {
        return money;
    }

    public float GetPitchPower()
    {
        return pitchPower;
    }

    public float GetMaxPitch()
    {
        return maxPitch;
    }

    public float GetYawPower()
    {
        return yawPower;
    }

    public float GetMaxYaw()
    {
        return maxYaw;
    }

    public float GetRollPower()
    {
        return rollPower;
    }

    public float GetMaxRoll()
    {
        return maxRoll;
    }

    public float GetHP()
    {
        return hp;
    }

    public float GetEnginePowerLevel()
    {
        return enginePowerLevelFloat;
    }

    public float GetManeuverabilityLevelFloat()
    {
        return maneuverabilityLevelFloat;
    }

    public float GetHpLevelFloat()
    {
        return hpLevelFloat;
    }
}

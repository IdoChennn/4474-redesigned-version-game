using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    Toggle thisToggle;
    string settingsFileName = "settings.txt";
    bool UISettings;
    public GameObject InGameUIObject;
    // Start is called before the first frame update
    void Start()
    {
        UISettings = true;
        thisToggle = GetComponent<Toggle>();
        LoadUISettings();
    }

    private void Update()
    {
        if(thisToggle != null)
        {
            thisToggle.isOn = UISettings;
        }
        if (InGameUIObject != null)
        {
            InGameUIObject.SetActive(UISettings);
        }
    }

    public void OnToggleChange()
    {
        if (File.Exists(settingsFileName))
        {
            ClearFile();
            StreamWriter writer = File.AppendText(settingsFileName);
            if (thisToggle.isOn)
            {
                writer.WriteLine("1");
                UISettings = true;
            } else
            {
                writer.WriteLine("0");
                UISettings = false;
            }
            writer.Close();
        } else
        {
            StreamWriter writer = File.AppendText(settingsFileName);
            writer.WriteLine("1");
            UISettings = true;
            writer.Close();
        }
    }

    public void LoadUISettings()
    {
        if (File.Exists(settingsFileName))
        {
            StreamReader reader = File.OpenText(settingsFileName);
            if(int.Parse(reader.ReadLine()) == 1)
            {
                UISettings = true;
            } else
            {
                UISettings = false;
            }
            reader.Close();
        }
        else
        {
            StreamWriter writer = File.AppendText(settingsFileName);
            writer.WriteLine("1");
            UISettings = true;
            writer.Close();
        }
    }

    private void ClearFile()
    {
        File.WriteAllText(settingsFileName, "");
    }
}

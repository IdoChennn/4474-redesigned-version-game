using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class RaceHighscore : MonoBehaviour
{
    public GameObject highscoreObject;
    TMP_Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        string highscoreFileName = "highscore.txt";
        highscore = highscoreObject.GetComponent<TMP_Text>();
        if (File.Exists(highscoreFileName))
        {
            highscore.text = "Highscore: " + float.Parse(File.ReadAllText(highscoreFileName)).ToString("F2");
        }
        else
        {
            highscore.text = "Highscore: N/A";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

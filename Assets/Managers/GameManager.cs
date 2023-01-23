using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject playerObject;
    public GameObject lastRing;
    public GameObject firstRing;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject pauseUIManagerObject;
    public GameObject upgradeManagerObject;
    bool gameOver;
    bool highscoreRecorded;
    HealthManager playerHealth;
    UpgradeManager upgradeManager;
    float gameTime;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0;
        gameOver = false;
        highscoreRecorded = false;
        playerHealth = playerObject.GetComponent<HealthManager>();
        upgradeManager = upgradeManagerObject.GetComponent<UpgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.GetHP() <= 0)
        {
            Destroy(inGameUI);
            Destroy(pauseUI);
            gameOverUI.SetActive(true);
            gameOver = true;
        }
        if(firstRing == null && lastRing != null)
        {
            gameTime += Time.deltaTime;
        }
        if(lastRing == null && !highscoreRecorded)
        {
            highscoreRecorded = true;
            DoResult();
        }
    }

    public bool getGameOver()
    {
        return gameOver;
    }

    public float getGameTime()
    {
        return gameTime;
    }

    private void DoResult()
    {
        float highscore;
        string highscoreTxt;
        string highscoreFileName = "highscore.txt";
        if (File.Exists(highscoreFileName))
        {
            highscoreTxt = File.ReadAllText(highscoreFileName);
            if(!float.TryParse(highscoreTxt, out highscore))
            {
                highscore = 9999;
            }
            if (gameTime < highscore)
            {
                highscore = gameTime;
                highscoreTxt = highscore.ToString();
                File.WriteAllText(highscoreFileName, highscoreTxt);
            }
        } else
        {
            StreamWriter writer = File.AppendText(highscoreFileName);
            highscore = gameTime;
            highscoreTxt = highscore.ToString();
            writer.Write(highscoreTxt);
            writer.Close();
        }
        upgradeManager.LoadData();
        upgradeManager.AddMoney((100 - gameTime) * 50);
    }
}

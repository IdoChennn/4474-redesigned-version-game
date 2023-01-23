using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CombatGameManager : MonoBehaviour
{
    public GameObject upgradeManagerObject;
    public GameObject inGameUI;
    public GameObject playerObject;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject pauseUIManagerObject;
    public GameObject enemyHeli;
    float timer;
    float enemyHeliSpawnTimer;
    float spawnRange;
    float spawnHeight;
    bool gameOver;
    HealthManager playerHealth;
    UpgradeManager upgradeManager;
    float gameTime;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0;
        timer = 0;
        enemyHeliSpawnTimer = 3;
        spawnRange = 1000;
        spawnHeight = 50;
        gameOver = false;
        playerHealth = playerObject.GetComponent<HealthManager>();
        upgradeManager = upgradeManagerObject.GetComponent<UpgradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameTime += Time.deltaTime;
        if (gameTime > 2 && playerHealth.GetHP() <= 0)
        {
            Destroy(inGameUI);
            Destroy(pauseUI);
            gameOverUI.SetActive(true);
            gameOver = true;
        }
        if(timer > enemyHeliSpawnTimer)
        {
            timer = 0;
            float x = 0;
            float y = 0;
            float z = 0;
            System.Random random = new System.Random();
            x = (float)random.NextDouble() * (spawnRange/2 - spawnRange);
            z = (float)random.NextDouble() * (spawnRange/2 - spawnRange);
            y = spawnHeight;
            Vector3 spawnPos = new Vector3(x, y, z);
            Instantiate(enemyHeli, spawnPos, transform.rotation);
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
        upgradeManager.AddMoney(0);
    }
}

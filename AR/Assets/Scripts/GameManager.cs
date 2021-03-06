﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    private List<GameObject> allBlocks;
    public GameObject[] levelPrefabs;
    
    [HideInInspector]
    public int currentLevel = 0;
    
    private bool isGameCompleted = false;

    [HideInInspector]
    public int score = 0, nBullets = 5;

    private Canvas winCanvas, loseCanvas, inGameCanvas;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        ChangeScene("Menu");
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnLevelWasLoaded(int level)
    {
        isGameCompleted = false;

        if (SceneManager.GetActiveScene().name == "Game")
        {
            GameObject winGO = GameObject.Find("Win Canvas");
            GameObject loseGO = GameObject.Find("Lose Canvas");
            GameObject inGameGO = GameObject.Find("Ingame Canvas");

            winCanvas = winGO.GetComponent<Canvas>();
            loseCanvas = loseGO.GetComponent<Canvas>();
            inGameCanvas = inGameGO.GetComponent<Canvas>();

            CreateLevel();
        }
    }

    public void CreateLevel()
    {
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
        inGameCanvas.enabled = true;

        if (currentLevel < levelPrefabs.Length)
        {
            score = 0;
            nBullets = 5;

            GameObject lvl = Instantiate(levelPrefabs[currentLevel]);
            GameObject levelTarget = GameObject.Find("LevelTarget");
            levelTarget.transform.position = Vector3.zero;
            levelTarget.transform.localPosition = Vector3.zero;

            lvl.transform.parent = levelTarget.transform;

            StartCoroutine(TitleLevel());
        }

        else
            isGameCompleted = true;

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        allBlocks = new List<GameObject>();
        allBlocks.AddRange(blocks);
    }

    public void RemoveBlock(GameObject block)
    {
        if (allBlocks.Find(b=>b == block))
            allBlocks.Remove(block);

        if (allBlocks.Count == 0)
            Victory();
    }

    public void Victory()
    {
        winCanvas.enabled = true;
        inGameCanvas.enabled = false;
        loseCanvas.enabled = false;

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        
        for (int i = 0; i < blocks.Length; ++i)
            DestroyImmediate(blocks[i]);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < bullets.Length; ++i)
            DestroyImmediate(bullets[i]);

        GameObject tracker = GameObject.Find("LevelTarget");

        for (int i = 0; i < tracker.transform.childCount; ++i)
        {
            DestroyImmediate(tracker.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        if (isGameCompleted)
        {
            ChangeScene("Menu");
            currentLevel = 0;
        }

        if (SceneManager.GetActiveScene().name == "Game")
        {
            GameObject scoreGO = GameObject.Find("Points");
            Text scoreText = scoreGO.GetComponent<Text>();
                
            scoreText.text = "SCORE: " + score.ToString();

            GameObject bulletsGO = GameObject.Find("Bullets");
            Text bulletsText = bulletsGO.GetComponent<Text>();

            bulletsText.text = "Bullets: " + nBullets.ToString();

            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
            if (nBullets == 0 && blocks.Length > 0)
            {
                loseCanvas.enabled = true;
                inGameCanvas.enabled = false;
            }
        }
    }


    private IEnumerator TitleLevel()
    {
        GameObject Title; 
        Image rndrr;
        if (currentLevel == 0)
        {
            Title = GameObject.Find("Level1");
        }
        else if(currentLevel == 1)
        {
            Title = GameObject.Find("Level2");
        }
        else if (currentLevel == 2)
        {
            Title = GameObject.Find("Level3");
        }
        else
        {
            Title = GameObject.Find("Level4");
        }

        rndrr = Title.GetComponent<Image>();

        rndrr.enabled = true;

        yield return new WaitForSeconds(3);

        rndrr.enabled = false;
	}

}

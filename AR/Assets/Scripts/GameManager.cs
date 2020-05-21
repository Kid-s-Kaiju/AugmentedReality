using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    private List<GameObject> allBlocks;
    public GameObject[] levelPrefabs;
    
    private int currentLevel = 0;
    private bool isGameCompleted = false;

    [HideInInspector]
    public int score = 0, nBullets = 5;


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
            CreateLevel();
    }

    private void CreateLevel()
    {
        if (currentLevel < levelPrefabs.Length)
        {
            score = 0;
            nBullets = 5;

            GameObject lvl = Instantiate(levelPrefabs[currentLevel]);
            GameObject levelTarget = GameObject.Find("LevelTarget");
            
            lvl.transform.parent = levelTarget.transform;
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
        currentLevel++;

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        
        for (int i = 0; i < blocks.Length; ++i)
            DestroyImmediate(blocks[i]);

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        for (int i = 0; i < bullets.Length; ++i)
            DestroyImmediate(bullets[i]);           

        CreateLevel();
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
            GameObject scoreGO = GameObject.Find("Score");
            Text scoreText = scoreGO.GetComponent<Text>();

            scoreText.text = "SCORE: " + score.ToString();

            GameObject bulletsGO = GameObject.Find("Bullets");
            Text bulletsText = bulletsGO.GetComponent<Text>();

            bulletsText.text = "Bullets Remaining: " + nBullets.ToString();
        }
    }
}
